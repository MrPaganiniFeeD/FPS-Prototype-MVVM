using System;
using Player;
using Player.PlayerInputView;
using UnityEngine;
using ViewModel;

namespace CompositeRoot
{
    [Serializable]
    public class PlayerInputRoot
    {
        [SerializeField] private PlayerMovementInputView _playerMovementInputView;
        [SerializeField] private PlayerLookingInputView _lookingInputView;
        
        private IPlayerInputMovementHandlerViewModel _inputMovementViewModel;
        private IPlayerInputLookOnHandlerViewModel _inputLookOnViewModel;

        private PlayerInput _playerInput;
        private PlayerMovement _playerMovement;
        private ICameraRotation _cameraRotation;

        public PlayerInputRoot(PlayerMovement movement, ICameraRotation cameraRotation)
        {
            _playerMovement = movement;
            _cameraRotation = cameraRotation;
        }
        public void Init()
        {
            _playerInput = new PlayerInput();



            _inputMovementViewModel = new PlayerInputMovementViewModel(_playerMovement);
            _inputLookOnViewModel = new PlayerInputLookingViewModel(_cameraRotation);
            
            
                        
            //_playerMovementInputView.Init();
          //  _lookingInputView.Init(_inputLookOnViewModel);
        }
    }
}