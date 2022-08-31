using Assets.Scripts.Infrastructure.Services.AllServices;
using Assets.Scripts.Infrastructure.States.CoroutineRunner;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly ICoroutineRannerService _canvasRaycastFilter;
        private ICoroutineRannerService _coroutineRannerService;
        private Dictionary<Type, IExictablState> _states;
        private IExictablState _activeState;
        private GameBootstapper _gameBootstapper;
        private AllServices _containerServices;

        public GameStateMachine(GameBootstapper gameBootstapper)
        {
            _gameBootstapper = gameBootstapper;
            _containerServices = AllServices.Container;

            _states = new Dictionary<Type, IExictablState>()
            {
                [typeof(BootsrapState)] = new BootsrapState(this, _gameBootstapper, _containerServices),
                [typeof(LoadLevelState)] = new LoadLevelState(this),
                [typeof(SceneLoaderState)] = new SceneLoaderState( this, _containerServices.GetService<ICoroutineRannerService>() ),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();

            state.Enter();
        }
        
        public void Enter<TState, TPlayLoad>(TPlayLoad playLoad, Action onLoad = null) where TState : class, IPlayLoadState<TPlayLoad>
        {
            TState state = ChangeState<TState>();

            state.Enter(playLoad, onLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExictablState
        {
            _activeState?.Exit();

            TState state = _states[typeof(TState)] as TState;
            _activeState = state;

            return state;
        }
    }
}
