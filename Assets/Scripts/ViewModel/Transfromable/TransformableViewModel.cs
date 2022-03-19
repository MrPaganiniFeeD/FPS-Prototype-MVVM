using System;
using Model;
using UniRx;
using UnityEngine;
using ViewModel;

namespace Player
{
    public class TransformableViewModel : ITransformableViewModel
    {
        private readonly ReactiveProperty<Vector3> _position = new ReactiveProperty<Vector3>();
        private readonly ReactiveProperty<RotationLocal> _rotation = new ReactiveProperty<RotationLocal>();

        public event Action Enable;
        public event Action Disable;

        private ITransformable _model;


        public TransformableViewModel(ITransformable model)
        {
             _model = model;
            
            OnUpdatePosition(_model.Position);
            OnUpdateRotation(_model.Rotation);
            _model.ChangePosition += OnUpdatePosition;
            _model.ChangeRotation += OnUpdateRotation;
            _model.OnEnable += OnEnableModel;
            _model.OnDisable += OnDisableModel;
        }

        private void OnEnableModel()
        {
            Enable?.Invoke();
        }

        private void OnDisableModel()
        {
            Disable?.Invoke();
        }

        private void OnUpdatePosition(Vector3 position)
        {
            _position.Value = position;
        }

        private void OnUpdateRotation(RotationLocal rotation)
        {
            _rotation.Value = rotation;
        }

        public ReactiveProperty<Vector3> GetPosition()
        {
            return _position;
        }
        public ReactiveProperty<RotationLocal> GetRotation()
        {
            return _rotation;
        }

        public void Dispose()
        {
            _model.ChangePosition -= OnUpdatePosition;
            _model.ChangeRotation -= OnUpdateRotation;
            _model.OnEnable -= OnEnableModel;
            _model.OnDisable -= OnDisableModel;
        }
    }
}