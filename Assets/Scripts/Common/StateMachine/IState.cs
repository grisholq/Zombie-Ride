public interface IState
{
    void Enter();
    void Update();
    void FixedUpdate();
    void Exit();
    void SetStateMachine(IStateMachine stateMachine);
}