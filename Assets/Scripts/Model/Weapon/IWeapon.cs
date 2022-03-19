using System;
using Other.Weapon.Visitor;

public interface IWeapon
{
    event Action Fire;
    event Action Reload;
    event Action Scope;

    event Action<int> ChangeCartridge;
    event Action<int> ChangeMaxCountCartridge;

    void Shoot(float spread);
    void Aim(float delta);
    void Recharge();

    void Accept(IWeaponVisitor visitor);
}