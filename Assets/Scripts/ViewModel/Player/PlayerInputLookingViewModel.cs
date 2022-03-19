using System;
using Model;
using UnityEngine;
using UnityEngine.UIElements;
using ViewModel;

namespace Player
{
    public class PlayerInputLookingViewModel : IPlayerInputLookOnHandlerViewModel
    {
        public event Action EnableInput;
        public event Action DisableInput;

        private ICameraRotation _cameraRotation;

        public PlayerInputLookingViewModel(ICameraRotation playerMovement)
        {
            _cameraRotation = playerMovement;
        }        
        public void Rotate(Vector2 input)
        {
            _cameraRotation.SetRotation(ConvertVectorToLocalRotation(input));
        }

        private RotationLocal ConvertVectorToLocalRotation(Vector2 direction)
        {
            return new RotationLocal(direction.x, direction.y, 0);
        }

        public void Dispose()
        {       
        }
    }
}