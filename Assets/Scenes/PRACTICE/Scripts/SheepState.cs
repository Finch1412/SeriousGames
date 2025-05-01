public abstract class SheepState
{
    protected SheepFSM fsm;
    protected SheepFSM.Sheep sheep;

    public SheepState(SheepFSM fsm, SheepFSM.Sheep sheep)
    {
        this.fsm = fsm;
        this.sheep = sheep;
    }

    public virtual void Enter() { }
    public virtual void Tick() { }
    public virtual void Exit() { }
}