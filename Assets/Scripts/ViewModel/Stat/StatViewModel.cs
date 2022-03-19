using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using ViewModel;
using ViewModel.Physics;

namespace Player.Model.Stats.StatViewModel
{
    public class StatViewModel : ITextViewModel
    {
        public event Action<string> ChangeAnyValue;
        private Stat _model;
        private ReactiveProperty<string> _stringProperty = new ReactiveProperty<string>();
        
        public StatViewModel(Stat model)
        {
            _model = model;
            OnStateChanged();
            _model.StateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            _stringProperty.Value = _model.Value.ToString();
        }

        public ReactiveProperty<string> GetChangeValue()
        {
            return _stringProperty;
        }
        public void Dispose()
        {
            _model.StateChanged -= OnStateChanged;
        }
    }
}