using Assets.Scripts.Infrastructure.States;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstapper : MonoBehaviour
    {
        GameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine = new GameStateMachine();
            _gameStateMachine.Enter<BootsrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
