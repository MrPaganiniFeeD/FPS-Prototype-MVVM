using System;
using System.Runtime.CompilerServices;
using Model.Components;
using UniRx;
using UnityEngine;

namespace ViewModel.Damageble
{
    public class DamageableViewModel : ITextViewModel, IDamageableViewModel
    {
        public event Action<string> ChangeAnyValue;
        public event Action TakingDamage;
        private IModelDamageable _damageable;
        private ReactiveProperty<string> _applyingDamage = new ReactiveProperty<string>();


        public DamageableViewModel(IModelDamageable damageable)
        {
            _damageable = damageable;
            _damageable.ChangeDamage += OnChangeDamage;
        }

        public ReactiveProperty<string> GetChangeValue()
        {
            return _applyingDamage;
        }

        private void OnChangeDamage(int value)
        {
            var valueString = value.ToString();
            ChangeAnyValue?.Invoke(valueString);
            TakingDamage?.Invoke();
        }

        public void Dispose()
        {
            _damageable.ChangeDamage -= OnChangeDamage;
        }
    }
}