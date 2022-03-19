using Player.Weapon.Recoil;
using View;

namespace Player.Weapon.Model
{
    public interface IRecoilWeapon
    {
        IRecoilInfo RecoilInfo { get; }
        ICameraRotation CameraRotation { get; }
        
        void RecoilPattern(int currentCartridge);
    }
}