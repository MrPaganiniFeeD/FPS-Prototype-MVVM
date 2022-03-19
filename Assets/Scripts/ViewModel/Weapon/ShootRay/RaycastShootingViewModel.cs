using System;
using Other.Weapon.Data.Raycast;
using Other.Weapon.Visitor;
using UniRx;
using UnityEngine;

namespace Player.Weapon.ViewModel.ShootRay
{
    public class RaycastShootingViewModel : IRaycastShootingViewModel
    {
        private ReactiveProperty<IRaycastInfo> _shootInfo =
            new ReactiveProperty<IRaycastInfo>();
        
        public event Action<IRaycastInfo, float> RaycastShoot;
        
        private WeaponRaycastAttack _weapon;
        
        public RaycastShootingViewModel(WeaponRaycastAttack weapon)
        {
            _weapon = weapon;
            _weapon.RaycastFire += OnRaycastShooting;
        }

        private void OnRaycastShooting(IRaycastInfo raycastInfo, float spread)
        {
            RaycastShoot?.Invoke(raycastInfo, spread);
        }
        
        public void Accept(IWeaponVisitor visitor)
        {
            _weapon.Accept(visitor);
        }

        public void Dispose()
        {
            _weapon.RaycastFire -= OnRaycastShooting;
        }
    }
}