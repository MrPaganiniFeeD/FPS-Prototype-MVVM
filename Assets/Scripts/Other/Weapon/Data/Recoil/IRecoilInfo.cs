using System.Collections.Generic;

namespace Player.Weapon.Recoil
{
    public interface IRecoilInfo
    {
        bool IsRecoil { get; set; }
        IEnumerable<float> Points { get; }

        int TimeSmooth { get; }
        float SmoothX { get; }
        float SmoothY { get; }

        float X { get; }
        float Y { get; }
        float Z { get; }
    }
}