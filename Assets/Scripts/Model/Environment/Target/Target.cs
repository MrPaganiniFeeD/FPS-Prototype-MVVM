using System;
using Model;
using Model.Components;
using Model.Physics;
using Other.Weapon.Visitor;
using Player.Stats;
using Player.Weapon.Model.OtherWeapon;
using UnityEngine;

public class Target : IModel, IDesiredModel, IModelDamageable, ITransformable, IWeaponVisitor
{
    public event Action<int> ChangeDamage;
    public event Action OnEnable;
    public event Action OnDisable;

    public event Action<Vector3> ChangePosition;
    public event Action<RotationLocal> ChangeRotation;

    public Vector3 Position { get; private set; }
    public RotationLocal Rotation { get; private set; }
    public Health Health { get; }
    
    public Target(Vector3 position, RotationLocal rotation, Health health)
    {
        Position = position;
        Rotation = rotation;
        Health = health;
    }

    public void ApplyDamage(int damage)
    {
        ChangeDamage?.Invoke(damage);
        Health.Value -= damage;
    }


    public void SetPosition(Vector3 newPosition)
    {
        Position = newPosition;
    }

    public void SetRotation(RotationLocal rotation)
    {
        Rotation = rotation;
    }

    public void Enable()
    {
        OnEnable?.Invoke();
    }

    public void Disable()
    {
        OnDisable?.Invoke();
    } 
    public void Visit(Galil galil)
    {
        ApplyDamage(galil.Info.Damage);
    }
}
