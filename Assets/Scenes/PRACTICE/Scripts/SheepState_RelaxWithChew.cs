using UnityEngine;

public class SheepState_RelaxWithChew : SheepState
{
    private float chewTime;
    private float timer;

    public SheepState_RelaxWithChew(SheepFSM fsm, SheepFSM.Sheep sheep) : base(fsm, sheep) {}

    public override void Enter()
    {
        sheep.animator.SetBool("IsCud", true);
        chewTime = Random.Range(10f, 20f);
        timer = 0f;
    }

    public override void Tick()
    {
        timer += Time.deltaTime;
        if (timer > chewTime)
        {
            fsm.SetState(new SheepState_Wander(fsm, sheep));
        }
    }

    public override void Exit()
    {
        sheep.animator.SetBool("IsCud", false);
        sheep.animator.SetBool("IsRelax", false);
    }
}