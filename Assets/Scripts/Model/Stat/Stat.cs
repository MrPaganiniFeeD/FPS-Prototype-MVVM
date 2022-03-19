using System;
using UniRx;
using UnityEngine;

namespace Player.Model.Stats
{
    [Serializable]
    public abstract class Stat : IStat
    {
        public event Action StateChanged;
        
        [SerializeField] private string _name;
        [SerializeField] private int _value;

        public string Name => _name;

        public int Value
        {
            get => _value;
            set
            {
                if (value > MaxValue)
                {
                    value = MaxValue;
                }
                _value = value;
                StateChanged?.Invoke();
            }
        }

        public int MaxValue { get; }

        protected Stat(string name, int maxValue)
        {
            _name = name;
            MaxValue = maxValue;
            Value = maxValue;
        }
        protected Stat(string name, int currentValue, int maxValue)
        {
            _name = name;
            Value = currentValue;
            MaxValue = maxValue;
        }
    }
}