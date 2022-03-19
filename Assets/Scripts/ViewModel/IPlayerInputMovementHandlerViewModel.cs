using System;
using UniRx;
using UnityEngine;

namespace ViewModel
{
    public interface IPlayerInputMovementHandlerViewModel : IViewModel
    {
        event Action EnableMovementInput;
        event Action DisableMovementInput;
        
        void Move(Vector2 direction, Vector3 forward, Vector3 right);
    }
}