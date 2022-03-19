using System;

namespace Model.Environment.Explosive
{
    public interface IExploding
    {
        event Action Explosion;
        
        void Explode();
    }
}