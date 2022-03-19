using Components;
using Model;
using Model.Projectile;
using Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using View.Projectile;
using ViewModel;

namespace CompositeRoot.Weapon
{
    public class ProjectileRoot : MonoBehaviour, IRoot
    {
        [SerializeField] private ProjectileView _view;
        [SerializeField] private ProjectileImpactHitView _impactHitView;
        [SerializeField] private Transform _transform;
        
        private Projectile _projectile;
        private ProjectileMovement _projectileMovement;

        private ITransformableViewModel _transformableViewModel;
        private CompositeDisposable _disposable = new CompositeDisposable();

        public void Init()
        {
            //model
            _projectile = new Projectile(_transform.position, new RotationLocal(
                _transform.rotation.x, _transform.rotation.y, _transform.rotation.z));
            _projectileMovement = new ProjectileMovement(_projectile, _transform.forward);
            
            _projectileMovement.Move();

            //viewModel
            _transformableViewModel = new TransformableViewModel(_projectile);
            
            //view
            _view.Init(_transformableViewModel);
            _impactHitView.Init();
        }
    }
}