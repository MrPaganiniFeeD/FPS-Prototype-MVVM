using System;
using UniRx;
using UnityEngine;

namespace ViewModel
{
    public interface ITextViewModel : IViewModel
    {
        event Action<string> ChangeAnyValue;
        ReactiveProperty<string> GetChangeValue();
        
    }
}