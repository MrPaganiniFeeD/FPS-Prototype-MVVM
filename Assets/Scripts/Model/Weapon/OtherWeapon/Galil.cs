using Model;
using Other.Weapon.Data.Aim;
using Other.Weapon.Data.Raycast;
using Other.Weapon.Data.WeaponInof;
using Other.Weapon.Visitor;
using Player.Weapon.Recoil;
using UnityEngine;

namespace Player.Weapon.Model.OtherWeapon
{
    public class Galil : WeaponRaycastAttack
    {
        public Galil(IWeaponRaycastShootingInfo info,
            IRecoilWeapon recoil, IAimingWeapon aimingWeapon, Vector3 position, RotationLocal rotation) :
            base(info, recoil, aimingWeapon, position, rotation)
        {
            
        }

        public override void Accept(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}