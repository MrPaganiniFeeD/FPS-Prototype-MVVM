using System;
using Components;
using UnityEngine;

namespace Model.Projectile
{
    public class Projectile : IModel, ITransformable
    {
        public event Action OnEnable;
        public event Action OnDisable;
        public event Action<Vector3> ChangePosition;
        public event Action<RotationLocal> ChangeRotation;
        
        private Vector3 _currentPosition;
        private Vector3 _newPosition;
        private RotationLocal _currentRotation;

        public Vector3 Position
        {
            get => _currentPosition;
            private set
            {
                _currentPosition = value;
                ChangePosition?.Invoke(_currentPosition);
            }
        }
        public RotationLocal Rotation
        {
            get => _currentRotation;
            private set
            {
                _currentRotation = value;
                ChangeRotation?.Invoke(_currentRotation);
            }
        }

        public Projectile(Vector3 position, RotationLocal rotation)
        {
            Position = position;
            Rotation = rotation;
        }
        public void SetPosition(Vector3 newPosition)
        {
            Position += newPosition;
        }
        public void SetRotation(RotationLocal rotation)
        {
            Rotation = rotation;
        }

        public void Update(float deltaTime)
        {
            Position = _newPosition * deltaTime;
        }

        public void FixedUpdate(float deltaTime)
        { 
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }
        public void Disable()
        {
            throw new NotImplementedException();
        }
    }
}