using CompositeRoot.Weapon;
using Other.Pool.Mono;
using Player.Weapon.ViewModel;
using UniRx;
using UnityEngine;
using View;
using ViewModel.Hit;

namespace Player.Weapon.View
{
    public class WeaponFXView : MonoBehaviour, IView<IWeaponViewModel>
    {
        [SerializeField] private ParticleSystem _fireParticelSystem;
        [SerializeField] private ParticleSystem _sparksParticleSystem;
        [SerializeField] private ProjectileRoot _projectileRoot;
        [SerializeField] private Transform _containerProjectPool;
        [SerializeField] private Transform _muzzleSocket;
        public IWeaponViewModel ViewModel { get; private set; }

        private CompositeDisposable _disposable = new CompositeDisposable();

        private IHitViewModel _hitViewModel;
        private PoolMono<ProjectileRoot> _projectilePool;
        private RaycastHit _hit;
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(IWeaponViewModel viewModel, IHitViewModel hitViewModel)
        {
            ViewModel = viewModel;
            _hitViewModel = hitViewModel;
            _hitViewModel.GetRaycastHit().Skip(1).Subscribe(UpdateHit).AddTo(_disposable);
            _projectilePool = new PoolMono<ProjectileRoot>(
                _projectileRoot, 10, true, null);
            ViewModel.Shoot += OnShoot;
        }
        private void UpdateHit(RaycastHit hit)
        {
            var projectileRoot = _projectilePool.GetFreeElement();
            projectileRoot.transform.position = _muzzleSocket.position;
            projectileRoot.transform.rotation = Quaternion.LookRotation(hit.point - _muzzleSocket.position);
            projectileRoot.Init();
        }
        private void OnShoot()
        {
            _fireParticelSystem.Play();
            _sparksParticleSystem.Play();
        }
        private void OnDisable()
        {
            if(ViewModel != null)
                ViewModel.Shoot -= OnShoot;
        }
    }
}