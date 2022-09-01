using Assets.Scripts.Infrastructure.States.CoroutineRunner;
using System;
using System.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.States
{
    public class SceneLoaderState : IPlayLoadState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private ICoroutineRannerService _corouteineRanner;

        public SceneLoaderState(GameStateMachine gameStateMachine, ICoroutineRannerService corouteineRanner)
        {
            _gameStateMachine = gameStateMachine;
            _corouteineRanner = corouteineRanner;
        }

        public void Enter(string playLoad, Action OnSceneLoad)
        {
            _corouteineRanner.StartCoroutine( Load(playLoad, OnSceneLoad) );
        }

        public void Exit()
        {

        }

        private IEnumerator Load(string nextScene, Action OnSceneLoad)
        {
            if(SceneManager.GetActiveScene().name == nextScene)
            {
                OnSceneLoad?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            OnSceneLoad?.Invoke();
        }
    }
}