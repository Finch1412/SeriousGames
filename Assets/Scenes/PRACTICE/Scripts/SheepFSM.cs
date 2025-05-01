using UnityEngine;
using UnityEngine.AI;

public class SheepFSM : MonoBehaviour
{
    private SheepState currentState;

    [System.Serializable]
    public class Sheep
    {
        public Animator animator;
        public NavMeshAgent agent;
        public bool lambing = false;
    }

    public Sheep sheep;

    void Start()
    {
        SetState(new SheepState_Wander(this, sheep));
    }

    void Update()
    {
        currentState?.Tick();
    }

    public void SetState(SheepState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}