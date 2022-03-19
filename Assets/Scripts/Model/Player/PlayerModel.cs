using System;
using System.Data;
using Components;
using Infostruct.Data;
using Model;
using Model.Physics;
using Other.Weapon.Visitor;
using UnityEngine;
using Player.Stats;

namespace Player
{
    public class PlayerModel : ITransformable, IDesiredModel, IUpdateable
    {
        public event Action OnEnable;
        public event Action OnDisable;
        public event Action<Vector3> ChangePosition;
        public event Action<RotationLocal> ChangeRotation;

        private IPlayerSettings _playerSettings;
        private ICameraRotation _cameraRotation;

        public Vector3 Position
        {
            get => _currentPosition;
            private set
            {
                if(_newPosition != _currentPosition)
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

        private RotationLocal _currentRotation;
        private RotationLocal _newRotation;

        private Vector3 _currentPosition;
        private Vector3 _newPosition;
        private PlayerStats _playerStats;

        public PlayerModel(Vector3 position,
            ref RotationLocal rotation,
            IPlayerSettings playerSettings,
            PlayerStats playerStats)
        {
            Position = position;
            Rotation = rotation;
            _playerSettings = playerSettings;
            _playerStats = playerStats;
        }
        public void Update(float deltaTime)
        {
            Position = _newPosition * deltaTime;
        }

        public void FixedUpdate(float deltaTime)
        {
            
        }

        public void SetPosition(Vector3 newPosition)
        {
            _newPosition = newPosition;
        }
        public void SetRotation(RotationLocal newRotation)
        {
            Rotation = newRotation;
        }
        public void Enable()
        {
            OnEnable?.Invoke();
        }
        public void Disable()
        {
            OnDisable?.Invoke();
        }
    }
}