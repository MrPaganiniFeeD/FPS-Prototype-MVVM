using System;
using UniRx;
using UnityEngine;
using ViewModel;

namespace Player
{
    public class PlayerInputMovementViewModel : IPlayerInputMovementHandlerViewModel
    {
        public event Action EnableMovementInput;
        public event Action DisableMovementInput;

        private PlayerMovement _movement;


        public PlayerInputMovementViewModel(PlayerMovement model)
        {
            _movement = model;
        }
        
        public void Move(Vector2 direction, Vector3 forward, Vector3 right)
        {
            _movement.Move(direction, forward, right);
        }

        public void Dispose()
        {
        }
    }
}