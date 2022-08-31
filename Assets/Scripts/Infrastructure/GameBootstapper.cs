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
            _gameStateMachine = new GameStateMachine(this);
            _gameStateMachine.Enter<BootsrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
