using Model.StateMachine.State;
using Model.StateMachine.Type;

namespace Model.StateMachine.Fabric
{
    public interface IFabricState<out T> where T : IState
    {
        T CreationState(TypeState typeState);
    }
}