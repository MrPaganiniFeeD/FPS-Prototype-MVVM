using DefaultNamespace;
using Model.StateMachine.Type;

namespace Model.StateMachine.Fabric
{
    public interface IFabricTransition<out T> where T : ITransition
    {
        T CreateTransition(TypeTransition type);
    }
}