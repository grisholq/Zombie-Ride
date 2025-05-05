public class ZombiePersuitState : IState
{
    private ZombieMovement movement;
    private IStateMachine stateMachine;
    
    public ZombiePersuitState(ZombieMovement movement)
    {
        this.movement = movement;
    }
    
    public void SetStateMachine(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
    }

    public void Update()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Exit()
    {
    }
}