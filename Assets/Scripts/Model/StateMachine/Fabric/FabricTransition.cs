using System;
using DefaultNamespace;
using Model.StateMachine.Type;
using UnityEngine.Analytics;
using Zenject;

namespace Model.StateMachine.Fabric
{
    public class FabricTransition : IFabricTransition<ITransition>
    {
        public ITransition CreateTransition(TypeTransition type)
        {
            return type switch
            {
                TypeTransition.Idle => new IdleTransition(),
                TypeTransition.Move => new MoveTransition(),
                TypeTransition.Unknown => new UnknownTransition(),

                _ => new UnknownTransition()
            };
        }
    }
}