using System;
using UnityEngine;

namespace Other.Weapon.Data.Aim
{
    [Serializable]
    public class AimInfo : IAimInfo
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _aimPosition;
        public float Speed => _speed;
        public Vector3 AimPosition => _aimPosition;
    }
}