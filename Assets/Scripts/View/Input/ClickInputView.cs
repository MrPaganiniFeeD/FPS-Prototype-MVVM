using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ViewModel;

namespace View
{
    public class ClickInputView : MonoBehaviour, IView<IClickInputViewModel>
    {
        private PlayerInput _playerInput;


        public IClickInputViewModel ViewModel { get; private set; }
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(IClickInputViewModel viewModel)
        {
             ViewModel = viewModel;
            _playerInput = new PlayerInput();
            _playerInput.Enable();
            _playerInput.OnFoot.LeftClick.Enable();
            _playerInput.OnFoot.RightClick.Enable();
        }

        private void Update()
        {
            if (_playerInput.OnFoot.LeftClick.inProgress)
            {
                ViewModel.LeftClick(Time.deltaTime);   
            }
            if (_playerInput.OnFoot.RightClick.inProgress)
            {
                ViewModel.RightClick(Time.deltaTime);
            }

        }

        private void OnDisable()
        {
            
        }
    }
}