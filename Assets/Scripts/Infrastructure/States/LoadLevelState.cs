using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPlayLoadState<string>, IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly FactoryService _factory;

        public LoadLevelState(GameStateMachine gameStateMachine, FactoryService factory)
        {
            _gameStateMachine = gameStateMachine;
            _factory = factory;
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

            _factory.CreateUnit();
            Debug.Log($"OnSceneLoad {SceneManager.GetActiveScene().name}");
        }
    }
}
