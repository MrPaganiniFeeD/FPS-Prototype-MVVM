using System.Linq;
using Player.Weapon.Recoil;
using UnityEngine;

namespace Player.Weapon.Model
{
    public class RecoilWeapon : IRecoilWeapon
    {
        public IRecoilInfo RecoilInfo { get; }
        public ICameraRotation CameraRotation { get; }
        
        private float _currentRecoilXPos;
        private float _currentRecoilYPos;


        public RecoilWeapon(ICameraRotation cameraRotation, IRecoilInfo recoilInfo)
        {
            CameraRotation = cameraRotation;
            RecoilInfo = recoilInfo;
        }
        public void RecoilPattern(int currentCartridge)
        {
            if (currentCartridge > RecoilInfo.Points.Count() - 1)
            {
                return;
            }
            
            var recoilPoint = RecoilInfo.Points.ElementAt(currentCartridge);
            _currentRecoilXPos = RecoilInfo.X * recoilPoint;
            _currentRecoilYPos = RecoilInfo.Y;

            CameraRotation.RecoilRotate(Mathf.Abs(_currentRecoilYPos), _currentRecoilXPos);         
            CameraRotation.SetSmoothRotationForTime(RecoilInfo.SmoothX, RecoilInfo.SmoothY, RecoilInfo.TimeSmooth);
        }
    }
}