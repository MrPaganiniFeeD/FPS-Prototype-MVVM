using System;
using Player.Stats;

namespace Model.Components
{
    public interface IModelDamageable
    {
        event Action<int> ChangeDamage;
        
        Health Health { get; }
        void ApplyDamage(int damage);
    }
}