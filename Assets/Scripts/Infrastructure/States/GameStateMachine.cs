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

        public GameStateMachine(ICoroutineRannerService coroutineRannerService)
        {
            _coroutineRannerService = coroutineRannerService;

            _states = new Dictionary<Type, IExictablState>()
            {
                [typeof(BootsrapState)] = new BootsrapState(this),
                [typeof(LoadLevelState)] = new LoadLevelState(this),
                [typeof(SceneLoaderState)] = new SceneLoaderState(this, _coroutineRannerService),
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
