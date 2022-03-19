using System;
using Other.Weapon.Data.Raycast;
using UnityEngine;

namespace Other.Weapon.Data.Raycast
{
    [Serializable]
    public class RaycastInfo : IRaycastInfo
    {
        [SerializeField] private float _range;
        public float Range => _range;
    }
}