using System;
using System.Collections.Generic;
using DefaultNamespace;
using Model.StateMachine.Machine;
using Model.StateMachine.Type;
using Other.Inventory;
using Player;
using UnityEngine;

namespace Model.StateMachine.State
{
    public class MoveState : IState
    {
        public event Action<TypeState> SwitchState;
        private float _speed = 15;
        private float _spread = 0.1f;
        private PlayerModel _player;
        private List<ITransition> _transitions;
        private readonly IInventory _inventory;


        public MoveState(PlayerModel player, IInventory inventory, List<ITransition> transitions)
        {
            _player = player;
            _inventory = inventory;
            _transitions = transitions;
        }

        public void Enter()
        {
        }

        public void Move(Vector2 direction, Vector3 forward, Vector3 right)
        {
            if(direction == Vector2.zero)
            {
                SwitchState?.Invoke(TypeState.Idle);
            }
            var nextPosition = (forward * direction.y + right * direction.x) * _speed;
            _player.SetPosition(nextPosition);   
        }
        
        public void Shoot()
        {
            _inventory.CurrentWeapon.Shoot(_spread);
        }
        
        public void Exit()
        {
        }
    }
}