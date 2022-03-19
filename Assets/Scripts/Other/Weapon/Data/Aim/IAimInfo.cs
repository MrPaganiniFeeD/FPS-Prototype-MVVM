using UnityEngine;

namespace Other.Weapon.Data.Aim
{
    public interface IAimInfo
    {
        float Speed { get; }

        Vector3 AimPosition { get; }
    }
}