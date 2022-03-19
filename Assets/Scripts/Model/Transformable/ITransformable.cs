using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Model
{
    public interface ITransformable
    {
        event Action OnEnable;
        event Action OnDisable;
        
        event Action<Vector3> ChangePosition;
        event Action<RotationLocal> ChangeRotation;
        
        Vector3 Position { get; }
        RotationLocal Rotation { get; }

        void SetPosition(Vector3 newPosition);
        void SetRotation(RotationLocal rotation);

        void Enable();
        void Disable(); 
    }
    
}