using System;
using System.Threading.Tasks;
using Components;
using Infostruct.Data;
using Model;
using UnityEngine;

namespace Player
{
    public class CameraRotation : ICameraRotation, IUpdateable
    {
        public event Action<RotationLocal> ChangeRotation;
        private IPlayerSettings _playerSettings;


        private float _smoothRotationX;
        private float _smoothRotationY;
        
        private float _wantedYRotation;
        private float _wantedCameraXRotation;
        
        private float _rotationYVelocity;
        private float _cameraXVelocity;

        public RotationLocal Rotation { get; set; }

        private ITransformable _player;
        private float _currentYRotation;
        private float _currentCameraXRotation;

        public CameraRotation(ITransformable player, IPlayerSettings playerSettings)
        {
            _player = player;
            _playerSettings = playerSettings;
            Rotation = new RotationLocal();
            _smoothRotationX = 0.03f;
            _smoothRotationY = 0.03f;
        }

        public void Update(float deltaTime)
        {
        }
        public void FixedUpdate(float deltaTime)
        {
            Rotate(deltaTime);
        }
        private void Rotate(float deltaTime)
        {
            _wantedYRotation += Rotation.X * _playerSettings.SensitivityX * deltaTime;
            _wantedCameraXRotation -= Rotation.Y * _playerSettings.SensitivityY * deltaTime;

            _wantedCameraXRotation = Mathf.Clamp(_wantedCameraXRotation, -90, 60);

            _currentYRotation = Mathf.SmoothDamp( _currentYRotation,
                _wantedYRotation,
                ref _rotationYVelocity,
                _smoothRotationY);

            _currentCameraXRotation = Mathf.SmoothDamp(_currentCameraXRotation,
                _wantedCameraXRotation,
                ref _cameraXVelocity, 
                _smoothRotationX);

            _player.SetRotation(new RotationLocal(_currentCameraXRotation, _currentYRotation, 0));
        }
        public void SetRotation(RotationLocal rotation)
        {
            Rotation = rotation;
        }

        public void RotateInMiddle()
        {
            SetRotation(new RotationLocal(0,0,0));
        }

        public void RecoilRotate(float xRotation, float yRotation)
        {
            _wantedCameraXRotation -= xRotation;
            _wantedYRotation -= yRotation;
        }

        public async void SetSmoothRotationForTime(float smoothX, float smoothY, int time)
        {
            _smoothRotationX = smoothX;
            _smoothRotationY = smoothY;
            await Task.Delay(time);
            _smoothRotationX -= smoothX;
            _smoothRotationY -= smoothY;
        }

        public void Shake()
        {
            throw new NotImplementedException();
        }
    }
}