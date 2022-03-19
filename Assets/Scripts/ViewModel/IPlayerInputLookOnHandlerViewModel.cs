using System;
using UnityEngine;

namespace ViewModel
{
    public interface IPlayerInputLookOnHandlerViewModel : IViewModel
    {
        event Action EnableInput;
        event Action DisableInput;

        void Rotate(Vector2 input);
    }
}