using System;
using Model.StateMachine.Type;
using UnityEngine;

namespace Model.StateMachine.State
{
    public interface IState
    {
        event Action<TypeState> SwitchState;
        
        void Enter();
        void Shoot();
        void Move(Vector2 direction, Vector3 forward, Vector3 right);
        void Exit();
    }
}