using UnityEngine;
using UnityEngine.AI;

public class SheepState_Wander : SheepState
{
    private float timer;
    private float wanderTime;
    private float stuckTimer;
    private Vector3 lastPosition;
    private float checkInterval = 1f;
    private float checkTimer = 0f;
    private bool reachedDestination = false;

    public SheepState_Wander(SheepFSM fsm, SheepFSM.Sheep sheep) : base(fsm, sheep) { }

    public override void Enter()
    {
        sheep.animator.SetBool("IsWalking", true);
        SetRandomTarget();
        wanderTime = Random.Range(2f, 4f);
        timer = 0f;
        stuckTimer = 0f;
        checkTimer = 0f;
        lastPosition = sheep.agent.transform.position;
        reachedDestination = false;
    }

    public override void Tick()
    {
        if (!reachedDestination)
        {
            checkTimer += Time.deltaTime;
            stuckTimer += Time.deltaTime;

            if (checkTimer >= checkInterval)
            {
                float movedDistance = Vector3.Distance(sheep.agent.transform.position, lastPosition);
                if (movedDistance < 0.1f)
                {
                    // Sheep is stuck or blocked
                    Debug.Log("Sheep stuck. Picking new destination.");
                    SetRandomTarget();
                    stuckTimer = 0f;
                }

                lastPosition = sheep.agent.transform.position;
                checkTimer = 0f;
            }

            if (!sheep.agent.pathPending && sheep.agent.remainingDistance <= sheep.agent.stoppingDistance)
            {
                sheep.animator.SetBool("IsWalking", false);
                reachedDestination = true;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > wanderTime)
            {
                if (sheep.lambing && Random.value < 0.4f)
                    fsm.SetState(new SheepState_Pawing(fsm, sheep));
                else
                    fsm.SetState(new SheepState_RelaxWithoutChew(fsm, sheep));
            }
        }
    }

    public override void Exit()
    {
        sheep.animator.SetBool("IsWalking", false);
    }

    private void SetRandomTarget()
    {
        for (int i = 0; i < 10; i++) // Try a few times
        {
            Vector3 randomPoint = sheep.agent.transform.position + Random.insideUnitSphere * 5f;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 5f, NavMesh.AllAreas))
            {
                if (!sheep.agent.SetDestination(hit.position))
                {
                    continue;
                }
                break;
            }
        }
    }
}