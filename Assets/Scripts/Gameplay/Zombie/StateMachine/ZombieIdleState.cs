using System;

public class ZombieIdleState : IState, IDisposable
{    
    private ZombiePersuitTarget _persuitTarget;
    private ZombieAnimator zombieAnimator;
    private IStateMachine stateMachine;
    
    public ZombieIdleState(ZombiePersuitTarget persuitTarget, ZombieAnimator zombieAnimator)
    {
        this._persuitTarget = persuitTarget;
        this.zombieAnimator = zombieAnimator;
    }
    
    public void SetStateMachine(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        _persuitTarget.TargetAcquired += OnTargetAcquired;
        zombieAnimator.StopMovement();
    }

    private void OnTargetAcquired()
    {
        stateMachine.SwitchState<ZombiePersuitState>();
    }

    public void Update()
    {
        
    }

    public void FixedUpdate()
    {
        
    }

    public void Exit()
    {
        Dispose();
    }

    public void Dispose()
    {
        _persuitTarget.TargetAcquired -= OnTargetAcquired;
    }
}