using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using ViewModel;

namespace View.Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileView : MonoBehaviour, IView<ITransformableViewModel>
    {
        private CompositeDisposable _disposable = new CompositeDisposable();
        private Rigidbody _rigidbody;
        private bool _test;
        public ITransformableViewModel ViewModel { get; private set; }
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(ITransformableViewModel viewModel)
        {
            ViewModel = viewModel;
            _rigidbody = GetComponent<Rigidbody>();
            ViewModel.GetPosition().Subscribe(_ =>
            {
                _rigidbody.velocity = _;
                _disposable.Clear();
            }).AddTo(_disposable);
        }
        private void Move(Vector3 newVelocity)
        {
            _rigidbody.velocity = newVelocity;
        }

    }
}