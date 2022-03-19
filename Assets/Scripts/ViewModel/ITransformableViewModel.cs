using System;
using Model;
using UniRx;
using UnityEngine;

namespace ViewModel
{
    public interface ITransformableViewModel : IViewModel
    {
        event Action Enable;
        event Action Disable;

        ReactiveProperty<Vector3> GetPosition();
        ReactiveProperty<RotationLocal> GetRotation();
    }
}