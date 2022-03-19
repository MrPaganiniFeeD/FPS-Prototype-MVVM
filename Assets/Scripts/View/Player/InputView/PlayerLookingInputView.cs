using System;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using View;
using ViewModel;

namespace Player.PlayerInputView
{
    public class PlayerLookingInputView : MonoBehaviour, IView<IPlayerInputLookOnHandlerViewModel>
    {
        public IPlayerInputLookOnHandlerViewModel ViewModel { get; private set; }
        private PlayerInput _playerInput;
        private Vector2 _direction;

        public void Init() { throw new System.NotImplementedException(); }
        public void Init(IPlayerInputLookOnHandlerViewModel viewModel)
        {
            ViewModel = viewModel;
            _playerInput = new PlayerInput();
            _playerInput.Enable();
        }
        private void Update()
        {
            Rotate(_playerInput.OnFoot.Look.ReadValue<Vector2>());
        }
        private void Rotate(Vector2 direction)
        {
            ViewModel.Rotate(direction);
        }
    }
}