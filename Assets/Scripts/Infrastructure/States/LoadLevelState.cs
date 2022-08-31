using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPlayLoadState<string>, IState
    {
        private GameStateMachine _gameStateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(string levelName, Action onLoad)
        {
            _gameStateMachine.Enter<SceneLoaderState, string>(levelName, OnSceneLoad);
        }

        public void Enter()
        {
        }

        public void Exit()
        {

        }

        private void OnSceneLoad()
        {
            _gameStateMachine.Enter<LoadLevelState>();

            Debug.Log("OnLoad");
        }
    }
}
