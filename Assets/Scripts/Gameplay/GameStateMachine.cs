using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMachine : StateMachine, ITickable, IFixedTickable, IInitializable
{
    private GameInitState initState;
    private GameRunState runState;
    
    public GameStateMachine(GameInitState initState, GameRunState runState)
    {
        this.initState = initState;
        this.runState = runState;
    }
    
    public void Initialize()
    {
        AddState(initState);
        AddState(runState);
        SwitchState<GameInitState>();
    }
}
