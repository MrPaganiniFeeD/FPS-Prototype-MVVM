using System;
using UnityEngine;

namespace Other.Inventory
{
    public interface IInventory
    {
        event Action<IWeapon> ChangeCurrentWeapon;
        
        IWeapon CurrentWeapon { get; }
        Vector3 WeaponSlotPosition { get; }

        IInventory BindToFirsSlot(IWeapon weapon);
        IInventory BindToSecondSlot(IWeapon weapon);
        void SwitchWeapon(int index);
    }
}