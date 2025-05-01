using UnityEngine;

public class SheepState_Pawing : SheepState
{
    private float pawTime;
    private float timer;

    public SheepState_Pawing(SheepFSM fsm, SheepFSM.Sheep sheep) : base(fsm, sheep) {}

    public override void Enter()
    {
        sheep.animator.SetTrigger("PawGround");
        pawTime = Random.Range(1f, 2f);
        timer = 0f;
    }

    public override void Tick()
    {
        timer += Time.deltaTime;
        if (timer > pawTime)
        {
            fsm.SetState(new SheepState_Wander(fsm, sheep));
        }
    }

    public override void Exit() { }
}