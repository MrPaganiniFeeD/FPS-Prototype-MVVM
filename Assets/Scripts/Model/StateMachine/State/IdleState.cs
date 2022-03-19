using System;
using System.Collections.Generic;
using DefaultNamespace;
using Model.StateMachine.Machine;
using Model.StateMachine.Type;
using Other.Inventory;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Model.StateMachine.State
{
    public class IdleState : IState
    {
        public event Action<TypeState> SwitchState;
        private List<ITransition> _transitions;
        private readonly IInventory _inventory;


        public IdleState(IInventory inventory ,List<ITransition> transitions)
        {
            _inventory = inventory;
            _transitions = transitions;
        }
        
        public void Enter()
        {
            
        }

        public void Shoot()
        {
            _inventory.CurrentWeapon.Shoot(0);
        }

        public void Move(Vector2 direction, Vector3 forward, Vector3 right)
        {
            if(direction != Vector2.zero)
                SwitchState?.Invoke(TypeState.Move);

        }
        public void Exit()
        {
           
        }
    }
}