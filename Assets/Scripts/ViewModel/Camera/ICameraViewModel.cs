using System;
using Model;

namespace ViewModel
{
    public interface ICameraViewModel
    {
        event Action<RotationLocal> UpdateRotation;
    }
}