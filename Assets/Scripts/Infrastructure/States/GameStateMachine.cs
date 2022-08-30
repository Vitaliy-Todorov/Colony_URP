using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.States
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootsrapState)] = new BootsrapState(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }
    }
}
