using System;
using CompositeRoot.Weapon;
using UnityEngine;

namespace Other.Inventory
{
    public class Inventory : IInventory
    {
        public event Action<IWeapon> ChangeCurrentWeapon;

        public IWeapon CurrentWeapon
        {
            get => _currentWeapon;
            private set
            {
                _currentWeapon = value;
                ChangeCurrentWeapon?.Invoke(_currentWeapon);
            }
        }

        public Vector3 WeaponSlotPosition { get; }

        private IWeapon _firstSlotWeapon;
        private IWeapon _secondSlotWeapon;

        private IWeapon _currentWeapon;

        public Inventory()
        {
        }

        public IInventory BindToFirsSlot(IWeapon weapon)
        {
            _firstSlotWeapon = weapon;
            _currentWeapon = _firstSlotWeapon;
            return this;
        }

        public IInventory BindToSecondSlot(IWeapon weapon)
        {
            _secondSlotWeapon = weapon;
            return this;
        }

        public void SwitchWeapon(int index)
        {
            throw new NotImplementedException();
        }
        
    }
}