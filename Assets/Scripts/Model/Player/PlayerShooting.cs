using Model;
using Model.StateMachine.Machine;
using Other.Inventory;
using UnityEngine;

namespace Player
{
    public class PlayerShooting : IModel
    {
        private IInventory _inventory;
        private IStateMachine _stateMachine;
        public PlayerShooting(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Shoot(float deltaTime)
        {
            _stateMachine.CurrentState.Shoot();
        }

        public void Aim(float deltaTime)
        {
            _inventory.CurrentWeapon?.Aim(deltaTime);
        }
        public void Reload()
        {
            _inventory.CurrentWeapon?.Recharge();
        }
    }
}