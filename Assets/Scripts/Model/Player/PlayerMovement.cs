using System;
using Model;
using Model.StateMachine.Machine;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : IModel
    {
        private readonly IStateMachine _stateMachine;
        public PlayerMovement(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Move(Vector2 direction, Vector3 forward, Vector3 right)
        {
            _stateMachine.CurrentState.Move(direction, forward, right);
        }
    }
}