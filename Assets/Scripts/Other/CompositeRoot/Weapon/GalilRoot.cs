using System;
using CompositeRoot;
using CompositeRoot.Weapon;
using Infostruct.Data;
using Model;
using Player;
using Player.Weapon.Model;
using Player.Weapon.Model.OtherWeapon;
using Player.Weapon.View;
using Player.Weapon.View.Auidio;
using Player.Weapon.View.RaycastView;
using Player.Weapon.ViewModel;
using Player.Weapon.ViewModel.ShootRay;
using UnityEngine;
using ViewModel.Hit;
using Zenject;

public class GalilRoot : MonoBehaviour, IWeaponRoot
{
    [SerializeField] private WeaponFXView _fxView;
    [SerializeField] private WeaponAnimationView _animationView;
    [SerializeField] private RaycastShootingView _raycastView;
    [SerializeField] private WeaponRaycastAttackInfo _weaponInfo;
    [SerializeField] private WeaponAudioView _audioView;
    private GameplayCameraView _gameplayCameraView;

    public IWeapon Weapon => _galil;
    
    
    private Galil _galil;
    private IRecoilWeapon _recoil;
    private IAimingWeapon _aiming;
    private ICameraRotation _cameraRotation;

    private PlayerInput _playerInput;

    private IWeaponViewModel _viewModel;
    private IRaycastShootingViewModel _raycastShootingViewModel;
    private IHitViewModel _hitViewModel;
    private Transform _transform;


    [Inject]
    public void Constructor(IPlayerCompositeRoot playerRoot)
    {
        _cameraRotation = playerRoot.CameraRotation;
        _gameplayCameraView = playerRoot.GameplayCameraView;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void Init()
    {
        //Model
        _aiming = new AimWeapon(_weaponInfo.AimInfo, new Vector3());
        _recoil = new RecoilWeapon(_cameraRotation, _weaponInfo.RecoilInfo);
        _galil = new Galil(_weaponInfo, _recoil, _aiming, _transform.position,
            new RotationLocal(_transform.rotation.x, _transform.rotation.y, _transform.rotation.z));
        
        
        //ViewModel
        _viewModel = new WeaponViewModel(_galil);
        _raycastShootingViewModel = new RaycastShootingViewModel(_galil);
        _hitViewModel = new HitViewModel();

        //View
        _raycastView.Init(_raycastShootingViewModel, _gameplayCameraView, _hitViewModel);
        _audioView.Init(_viewModel);
        _animationView.Init(_viewModel);
        _fxView.Init(_viewModel, _hitViewModel);
    }
}
