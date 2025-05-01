using UnityEngine;

public class SheepState_Straining : SheepState
{
    private float strainTime;
    private float timer;

    public SheepState_Straining(SheepFSM fsm, SheepFSM.Sheep sheep) : base(fsm, sheep) {}

    public override void Enter()
    {
        sheep.animator.SetBool("IsLambing", true);
        strainTime = Random.Range(5f, 15f);
        timer = 0f;
    }

    public override void Tick()
    {
        timer += Time.deltaTime;
        if (timer > strainTime)
        {
            sheep.animator.SetBool("IsLambing", false);
            sheep.lambing = false; // simulate birth
            fsm.SetState(new SheepState_Wander(fsm, sheep));
        }
    }

    public override void Exit() {

        sheep.animator.SetBool("IsRelax", false);
    }
}