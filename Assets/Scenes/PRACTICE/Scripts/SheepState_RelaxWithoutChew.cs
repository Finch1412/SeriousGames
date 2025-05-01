using UnityEngine;

public class SheepState_RelaxWithoutChew : SheepState
{
    private float timer;
    private float relaxTime;

    public SheepState_RelaxWithoutChew(SheepFSM fsm, SheepFSM.Sheep sheep) : base(fsm, sheep) {}

    public override void Enter()
    {
        sheep.animator.SetBool("IsRelax", true);
        sheep.animator.SetBool("IsCud", false);
        relaxTime = Random.Range(10f, 20f);
        timer = 0f;
    }

    public override void Tick()
    {
        timer += Time.deltaTime;
        if (timer > relaxTime)
        {
            if (sheep.lambing && Random.value < 0.5f)
                fsm.SetState(new SheepState_Straining(fsm, sheep));
            else
                fsm.SetState(new SheepState_RelaxWithChew(fsm, sheep));
        }
    }

    public override void Exit()
    {
        //sheep.animator.SetBool("IsRelax", false);
    }
}