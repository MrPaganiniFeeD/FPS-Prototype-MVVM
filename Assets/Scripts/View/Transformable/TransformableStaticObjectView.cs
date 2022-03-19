using System;
using Model;
using UniRx;
using UnityEngine;
using ViewModel;

namespace View.Transformable
{
    public class TransformableStaticObjectView : MonoBehaviour, IView<ITransformableViewModel>
    {
        public ITransformableViewModel ViewModel { get; private set; }
        private CompositeDisposable _disposable = new CompositeDisposable();
        private GameplayCameraView _cameraView;
        
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(ITransformableViewModel viewModel, GameplayCameraView gameplayCameraView)
        {
            ViewModel = viewModel;
            _cameraView = gameplayCameraView;
            ViewModel.Enable += OnEnableView;
            ViewModel.Disable += OnDisableView;
            ViewModel.GetPosition().Subscribe(ViewPosition).AddTo(_disposable);
            ViewModel.GetRotation().Subscribe(ViewRotation).AddTo(_disposable);
        }
        private void ViewPosition(Vector3 modelPosition)
        {
            transform.position = modelPosition;
        }
        private void ViewRotation(RotationLocal rotationLocal)
        {
          
        }
        private void OnEnableView()
        {
            this.enabled = true;
        }
        private void OnDisableView()
        {
            this.enabled = false;
        }
        private void OnDestroy()
        {
            ViewModel.Enable -= OnEnableView;
            ViewModel.Disable -= OnDisableView;
            ViewModel.Dispose();
        }
    }
}