using System;
using System.IO;
using Other.Weapon.Visitor;
using ViewModel;

namespace Player.Weapon.ViewModel.ShootRay
{
    public interface IRaycastShootingViewModel : IViewModel
    {
        event Action<IRaycastInfo, float> RaycastShoot;
        void Accept(IWeaponVisitor visitor);
    }
}