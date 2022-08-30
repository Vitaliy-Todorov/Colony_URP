using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public class BootsrapState : IState
    {
        public void Enter()
        {
            Debug.Log("BootsrapState");
        }

        public void Exit()
        {
        }
    }
}
