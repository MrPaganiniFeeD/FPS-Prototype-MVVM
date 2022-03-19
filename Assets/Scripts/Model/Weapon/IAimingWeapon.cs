using UnityEngine;

namespace Player.Weapon.Model
{
    public interface IAimingWeapon
    {
        void Aim();
        void RemovingAim();
        Vector3 GetNewAimPosition(float delta);
        Vector3 GetNewRemovingAimPosition(float delta);
    }
}