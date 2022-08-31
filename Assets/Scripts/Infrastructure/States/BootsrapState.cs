using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public partial class BootsrapState : IState
    {
        private const string _main = "Main";
        GameStateMachine _gameStateMachine;

        public BootsrapState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;

            // RegisterServices();
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(_main);
        }

        public void Exit()
        {
        }
    }
}
