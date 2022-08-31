using Assets.Scripts.Infrastructure.Services.AllServices;
using Assets.Scripts.Infrastructure.States.CoroutineRunner;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public partial class BootsrapState : IState
    {
        private const string _main = "Main";
        GameStateMachine _gameStateMachine;
        private AllServices _containerServices;
        private readonly GameBootstapper _gameBootstapper;

        public BootsrapState(GameStateMachine gameStateMachine, GameBootstapper gameBootstapper, AllServices containerServices)
        {
            _gameStateMachine = gameStateMachine;
            _gameBootstapper = gameBootstapper;
            _containerServices = containerServices;

            RegisterServices();
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(_main);
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            _containerServices.RegisterService<ICoroutineRannerService>(CoroutineRanner() );
        }

        private CoroutineRannerService CoroutineRanner()
        {
            return _gameBootstapper.gameObject.AddComponent<CoroutineRannerService>();
        }
    }
}
