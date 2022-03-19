using System;
using UnityEngine;
using UnityEngine.InputSystem;
using View;
using ViewModel;

namespace Player.PlayerInputView
{
    public class PlayerMovementInputView : MonoBehaviour, IView<IPlayerInputMovementHandlerViewModel>
    {
        private PlayerInput _playerInput;

        public IPlayerInputMovementHandlerViewModel ViewModel { get; private set; }

        public void Init() { throw new System.NotImplementedException(); }
        public void Init(IPlayerInputMovementHandlerViewModel movementHandlerViewModel)
        {
            ViewModel = movementHandlerViewModel;
            _playerInput = new PlayerInput();
            _playerInput.Enable();
            //_playerInput.OnFoot.Movement.performed += Move;
            ViewModel.EnableMovementInput += OnEnableInput;
            ViewModel.DisableMovementInput += OnDisableInput;
        }

        private void Update()
        {
            ViewModel.Move(GetMoveDirection(), transform.forward, transform.right);
        }

        private Vector2 GetMoveDirection()
        {
            return _playerInput.OnFoot.Movement.ReadValue<Vector2>();
        }
        private void OnEnableInput()
        {
            _playerInput.OnFoot.Movement.Enable();
        }

        private void OnDisableInput()
        {
            _playerInput.OnFoot.Movement.Disable();
        }
        private void OnDisable()
        {
            OnDisableInput();
            //_playerInput.OnFoot.Movement.performed -= Move;
            ViewModel.EnableMovementInput -= OnEnableInput;
            ViewModel.DisableMovementInput -= OnDisableInput;
        }
    }
}