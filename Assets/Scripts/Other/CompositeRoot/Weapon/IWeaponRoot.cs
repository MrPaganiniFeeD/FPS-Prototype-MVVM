namespace CompositeRoot.Weapon
{
    public interface IWeaponRoot : IRoot
    {
        public IWeapon Weapon { get; }
    }
}