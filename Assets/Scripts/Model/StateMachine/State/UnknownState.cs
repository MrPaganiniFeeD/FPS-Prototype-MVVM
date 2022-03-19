using System;
using Model.StateMachine.Type;
using UnityEngine;

namespace Model.StateMachine.State
{
    public class UnknownState : IState
    {
        public event Action<TypeState> SwitchState;

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Shoot()
        {
            throw new System.NotImplementedException();
        }

        public void Move(Vector2 direction, Vector3 forward, Vector3 right)
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}