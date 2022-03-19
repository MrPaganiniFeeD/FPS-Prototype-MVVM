using Other.Weapon.Visitor;
using Player.Weapon.ViewModel.ShootRay;
using UniRx;
using UnityEngine;
using View;
using View.Physics;
using ViewModel.Hit;

namespace Player.Weapon.View.RaycastView
{
    public class RaycastShootingView : MonoBehaviour, IView<IRaycastShootingViewModel>
    {
        public IRaycastShootingViewModel ViewModel { get; private set; }
        private IHitViewModel _hitViewModel;
        private CompositeDisposable _disposable = new CompositeDisposable();
        private RaycastHit _hit;
        private GameplayCameraView _gameplayCameraView;
        
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(IRaycastShootingViewModel viewModel, GameplayCameraView gameplayCameraView, 
            IHitViewModel hitViewModel)
        {
            ViewModel = viewModel;
            _gameplayCameraView = gameplayCameraView;
            _hitViewModel = hitViewModel;
            ViewModel.RaycastShoot += OnRaycastShoot;
            //ViewModel.Shot().Skip(1).Subscribe(OnRaycastShoot).AddTo(_disposable);
        }
        private void OnRaycastShoot(IRaycastInfo raycastInfo, float spread)
        {
            var shootDirection = _gameplayCameraView.transform.forward;
            shootDirection.x += GetRandomSpread(spread);
            shootDirection.y += GetRandomSpread(spread);

            if(Physics.Raycast(_gameplayCameraView.transform.position, 
                shootDirection, out _hit, raycastInfo.Range))
            {
                _hitViewModel.SetHit(_hit);
                if (_hit.collider.gameObject.TryGetComponent(out IRaycastDetectorView physicsDetector))
                {
                    physicsDetector.SetHit(_hit);
                    if(physicsDetector.TryGetModelType(out IWeaponVisitor visitor))
                    {
                        ViewModel.Accept(visitor);
                    }
                }
            }    
        }

        private float GetRandomSpread(float spread)
        {
            return Random.Range(-spread, spread);
        }
        private void OnDestroy()
        {
            ViewModel.Dispose();
            ViewModel.RaycastShoot -= OnRaycastShoot;
            ViewModel = null;
        }
    }
}