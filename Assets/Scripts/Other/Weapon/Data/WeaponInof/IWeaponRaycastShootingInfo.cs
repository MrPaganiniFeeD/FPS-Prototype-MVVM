namespace Other.Weapon.Data.WeaponInof
{
    public interface IWeaponRaycastShootingInfo : IWeaponInfo
    {
        IRaycastInfo RaycastInfo { get; }
    }
}