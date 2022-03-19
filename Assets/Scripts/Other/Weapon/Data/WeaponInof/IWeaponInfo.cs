using System.Collections;
using System.Collections.Generic;
using Other.Weapon.Data.Aim;
using Player.Weapon.Recoil;
using UnityEngine;

public interface IWeaponInfo
{
    int Damage { get; }
    float ReloadSpeed { get; }
    int ShootSpeed { get;}
    int MaxCountCartridge { get; }
    
    
    IRecoilInfo RecoilInfo { get; }
    IAimInfo AimInfo { get; }
}
