using Components;
using UnityEngine;

namespace Model.Projectile
{
    public class ProjectileMovement : IModel, IUpdateable
    {
        private ITransformable _transformable;
        private Vector3 _startDirection;
        private float _speed = 300;
        
        public ProjectileMovement(ITransformable transformable, Vector3 startDirection)
        {
            _transformable = transformable;
            _startDirection = startDirection;
        }

        public void Move(float deltaTime = 1)
        {
            _transformable.SetPosition(_startDirection * _speed * deltaTime);
        }
        public void Update(float deltaTime)
        {
            Move();
        }
        public void FixedUpdate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}