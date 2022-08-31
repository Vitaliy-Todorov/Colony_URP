using System;

namespace Assets.Scripts.Infrastructure.States
{
    public interface IState : IExictablState
    {
        void Enter();
    }

    public interface IPlayLoadState<TPlayLoade> : IExictablState
    {
        void Enter(TPlayLoade playLoad, Action onLoad = null);
    }

    public interface IExictablState
    {
        void Exit();
    }
}