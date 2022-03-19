using Player.Weapon.Model.OtherWeapon;

namespace Other.Weapon.Visitor
{
    public interface IWeaponVisitor
    {
        void Visit(Galil galil);
    }
}