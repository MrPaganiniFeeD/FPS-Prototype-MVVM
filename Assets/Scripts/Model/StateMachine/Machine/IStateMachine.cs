using System.Collections.Generic;
using Model.StateMachine.State;
using Model.StateMachine.Type;
using Player.Model.Stats;

namespace Model.StateMachine.Machine
{
    public interface IStateMachine
    {
        IState CurrentState { get; }
        Dictionary<TypeState, IState> AllStates { get; }
        void SwitchState(TypeState typeState);
    }
}