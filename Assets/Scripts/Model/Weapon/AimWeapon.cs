using System;
using Other.Weapon.Data.Aim;
using UnityEngine;

namespace Player.Weapon.Model
{
    public class AimWeapon : IAimingWeapon
    {
        private readonly Vector3 _originPosition;
        private Vector3 _currentPosition;

        private IAimInfo _aimInfo;
        
        public AimWeapon(IAimInfo aimInfo ,Vector3 originPosition)
        {
            _originPosition = originPosition;
            _aimInfo = aimInfo;
        }
        
        public void Aim()
        {
            
        }

        public void RemovingAim()
        {
            
        }
        public Vector3 GetNewAimPosition(float delta)
        {
            return GetPosition(delta, _aimInfo.AimPosition);
        }

        public Vector3 GetNewRemovingAimPosition(float delta)
        {
            return GetPosition(delta, _originPosition);
        }

        private Vector3 GetPosition(float delta, Vector3 targetPosition)
        {
            _currentPosition.x = Mathf.Lerp(_currentPosition.x, targetPosition.x, delta * _aimInfo.Speed);
            _currentPosition.y = Mathf.Lerp(_currentPosition.y,  targetPosition.y, delta * _aimInfo.Speed);
            _currentPosition.z = Mathf.Lerp(_currentPosition.z, targetPosition.z, delta * _aimInfo.Speed);
            return _currentPosition;
        }
    }
}