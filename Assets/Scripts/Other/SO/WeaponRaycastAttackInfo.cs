using Other.Weapon.Data.Raycast;
using Other.Weapon.Data.WeaponInof;
using UnityEngine;

namespace Infostruct.Data
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/Create new RaycastAttackWeapon", order = 51)]
    public class WeaponRaycastAttackInfo : WeaponInfo, IWeaponRaycastShootingInfo
    {
        [SerializeField] private RaycastInfo _raycastInfo;

        public IRaycastInfo RaycastInfo => _raycastInfo;
    }
}