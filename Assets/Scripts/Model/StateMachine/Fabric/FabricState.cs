using System.Collections.Generic;
using DefaultNamespace;
using Model.StateMachine.Machine;
using Model.StateMachine.State;
using Model.StateMachine.Type;
using Other.Inventory;
using Player;

namespace Model.StateMachine.Fabric
{
    public class FabricState : IFabricState<IState>
    {
        private PlayerModel _player;
        private IFabricTransition<ITransition> _fabricTransition;
        private readonly IInventory _inventory;

        public FabricState(PlayerModel player, IInventory inventory)
        {
            _player = player;
            _fabricTransition = new FabricTransition();
            _inventory = inventory;
        }
        public IState CreationState(TypeState typeState)
        {
            return typeState switch
            {
                TypeState.Idle => new IdleState(_inventory, new List<ITransition>
                {
                    _fabricTransition.CreateTransition(TypeTransition.Move),
                    _fabricTransition.CreateTransition(TypeTransition.Unknown)
                }),
                TypeState.Move => new MoveState(_player, _inventory, new List<ITransition> 
                {
                    _fabricTransition.CreateTransition(TypeTransition.Idle), 
                    _fabricTransition.CreateTransition(TypeTransition.Unknown)
                }),

                _ => new UnknownState()
            };
        }
    }
}