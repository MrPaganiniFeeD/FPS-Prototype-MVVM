using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultNamespace;
using Model.StateMachine.Fabric;
using Model.StateMachine.State;
using Model.StateMachine.Type;
using Other.Inventory;
using UnityEditor.Animations;

namespace Model.StateMachine.Machine
{
    public class StateMachine : IStateMachine
    {
        public IState CurrentState => _currentState;
        public Dictionary<TypeState, IState> AllStates => _allStates;

        private IState _currentState;
        private Dictionary<TypeState, IState> _allStates;

        private IFabricState<IState> _fabricState;

        public StateMachine(IFabricState<IState> fabricState)
        {
            _fabricState = fabricState;
            InitStates();
        }

        private void InitStates()
        {
            _allStates = new Dictionary<TypeState, IState>
            {
                {TypeState.Idle, _fabricState.CreationState(TypeState.Idle)},
                {TypeState.Move, _fabricState.CreationState(TypeState.Move)}
            };
            _currentState = _allStates[TypeState.Idle];
            _currentState.Enter();
            _currentState.SwitchState += SwitchState;
        }
        public void SwitchState(TypeState typeState)
        {
            _currentState.SwitchState -= SwitchState;
            var newState = _allStates[typeState];
            _currentState.Exit();
            newState.Enter();
            newState.SwitchState += SwitchState;
            _currentState = newState;
        }
    }
}