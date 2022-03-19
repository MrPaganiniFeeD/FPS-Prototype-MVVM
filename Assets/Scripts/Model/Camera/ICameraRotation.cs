using System;
using Model;

namespace Player
{
    public interface ICameraRotation
    {
        void SetRotation(RotationLocal rotation);
        void RotateInMiddle();

        void RecoilRotate(float xRotation, float yRotation);
        void SetSmoothRotationForTime(float smoothX, float smoothY, int time);
        void Shake();
    }
}