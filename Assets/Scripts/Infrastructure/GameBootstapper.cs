using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Infrastructure.States.CoroutineRunner;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstapper : MonoBehaviour
    {
        GameStateMachine _gameStateMachine;

        private void Awake()
        {
            ICoroutineRannerService canvasRaycastFilter = gameObject.AddComponent<CoroutineRannerService>();

            _gameStateMachine = new GameStateMachine(canvasRaycastFilter);
            _gameStateMachine.Enter<BootsrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
