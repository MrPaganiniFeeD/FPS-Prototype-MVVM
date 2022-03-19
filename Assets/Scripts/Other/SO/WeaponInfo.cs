using System.Collections;
using System.Collections.Generic;
using Other.Weapon.Data.Aim;
using Player.Weapon.Recoil;
using Player.Weapon.ViewModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/Create new Weapon", order = 51)]
public class WeaponInfo : ScriptableObject, IWeaponInfo
{
    [SerializeField] private int _damage;
    [SerializeField] private float _reloadSpeed;
    [SerializeField] private int _shootSpeed;
    [SerializeField] private int _maxCountCartridge;
    [SerializeField] private RecoilInfo _recoilInfo;
    [SerializeField] private AimInfo _aimInfo;

    public int Damage => _damage;
    public float ReloadSpeed => _reloadSpeed;
    public int ShootSpeed => _shootSpeed;
    public int MaxCountCartridge => _maxCountCartridge;
    public IRecoilInfo RecoilInfo => _recoilInfo;
    public IAimInfo AimInfo => _aimInfo;
}
