using System;
using Infostruct.Data;
using Model;
using UniRx;
using UniRx.Triggers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using View;
using ViewModel;

namespace Player
{
    public class PlayerView : MonoBehaviour, ITransformableView
    {
        [FormerlySerializedAs("gamePlayCameraView")] [FormerlySerializedAs("_playerCameraView")] [FormerlySerializedAs("_camera")] [SerializeField] private GameplayCameraView gameplayCameraView;
        [SerializeField] private Rigidbody _rigidbody;
        private Camera _camera;

        private Transform _transform;
        private Vector3 _currentRotation;
        private Vector3 _targetRotation;
        private RotationLocal _rotationLocal;
        private CompositeDisposable _disposable = new CompositeDisposable();
        private Vector3 _updatablePosition;
        public ITransformableViewModel ViewModel { get; private set; }
        
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(ITransformableViewModel viewModel)
        {
            ViewModel = viewModel;
            _transform = GetComponent<Transform>();
            _camera = gameplayCameraView.GetComponent<Camera>();
            ViewModel.GetPosition().Subscribe(SetNewPosition).AddTo(_disposable);
            ViewModel.GetRotation().Subscribe(Rotate).AddTo(_disposable);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        private void SetNewPosition(Vector3 position)
        {
            _updatablePosition = position;
        }
        private void Rotate(RotationLocal rotate)
        {
            _rotationLocal = rotate;
        }

        private void FixedUpdate()
        { 
            _rigidbody.MovePosition(_transform.position + _updatablePosition);
        }
        private void LateUpdate()
        { 
            _transform.rotation = Quaternion.Euler(0,_rotationLocal.Y,0);
           gameplayCameraView.transform.localRotation = Quaternion.Euler(_rotationLocal.X, 0, 0);
        }
        private void OnDestroy()
        {
            ViewModel.Dispose();
        }
    }
}