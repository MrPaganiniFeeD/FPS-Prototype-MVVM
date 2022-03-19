using System;
using System.Threading.Tasks;
using Model;
using Other.Weapon.Data.Raycast;
using Other.Weapon.Data.WeaponInof;
using Other.Weapon.Visitor;
using Player.Weapon.Model;
using UnityEngine;

public abstract class WeaponRaycastAttack : IWeapon, ITransformable
{
    public event Action Fire;
    public event Action Reload;
    public event Action Scope;
    public event Action<IRaycastInfo, float> RaycastFire;

    public event Action<int> ChangeCartridge;
    public event Action<int> ChangeMaxCountCartridge;
    public event Action<Vector3> ChangePosition;
    public event Action<RotationLocal> ChangeRotation;
    
    public event Action OnEnable;
    public event Action OnDisable;

    public Vector3 Position
    {
        get => _position;
        private set
        {
            _position = value;
            ChangePosition?.Invoke(_position);
        }
    }
    public RotationLocal Rotation
    {
        get => _rotation;
        private set
        {
            _rotation = value;
            ChangeRotation?.Invoke(_rotation);
        }
    }

    public int MaxCountCartridge
    {
        get => _maxCountCartridge;
        private set
        {
            _maxCountCartridge = value;
            ChangeMaxCountCartridge?.Invoke(_maxCountCartridge);
        }
    }

    public int CurrentNumberOfCartridge
    {
        get => _currentNumberOfCartridge;
        private set
        {
            _currentNumberOfCartridge = value;
            ChangeCartridge?.Invoke(_currentNumberOfCartridge);
        }
    }

    public IWeaponRaycastShootingInfo Info { get; private set; }


    private IRecoilWeapon _recoil;
    private int _maxCountCartridge = 30000;
    private int _currentNumberOfCartridge = 25;

    private bool _isShoot = true;
    private bool _isAim = false;

    private Vector3 _position;
    private RotationLocal _rotation;

    private IAimingWeapon _aimingWeapon;

    protected WeaponRaycastAttack(IWeaponRaycastShootingInfo info,
        IRecoilWeapon recoil, IAimingWeapon aimWeapon,
        Vector3 position, RotationLocal rotation)
    {
        Info = info;
        _recoil = recoil;
        _aimingWeapon = aimWeapon;
        _position = position;
        _rotation = rotation;
    }
    public void Shoot(float spread)
    {
        if (_currentNumberOfCartridge <= _maxCountCartridge && _currentNumberOfCartridge != 0 && _isShoot)
        {
            ShootingDelay();
            CurrentNumberOfCartridge--;
            Recoil(_currentNumberOfCartridge);
            Fire?.Invoke();
            RaycastFire?.Invoke(Info.RaycastInfo, spread);
            return;
        }

        if (_currentNumberOfCartridge == 0)
            _currentNumberOfCartridge = 25;
    }

    public void Aim(float delta)
    {
        if (_isAim == false)
        {
            Position = _aimingWeapon.GetNewAimPosition(delta);
            _isAim = true;
        }
        else
        {
            Position = _aimingWeapon.GetNewRemovingAimPosition(delta);
        }
    }

    private async void ShootingDelay()
    {
        _isShoot = false; 
        await Task.Delay(Info.ShootSpeed);
        _isShoot = true;
    }

    private void Recoil(int currentCartridge)
    {
        _recoil.RecoilPattern(currentCartridge);
    }

    public void Recharge() { throw new NotImplementedException(); }

    public void SetPosition(Vector3 newPosition) { throw new NotImplementedException(); }

    public void SetRotation(RotationLocal rotation) { }
    
    public void Enable()
    {
        OnEnable?.Invoke();
    }

    public void Disable()
    {
        OnDisable?.Invoke();
    }

    public abstract void Accept(IWeaponVisitor visitor);
    
}
