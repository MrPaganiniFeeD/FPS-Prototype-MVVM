using System;
using UniRx;

namespace Player.Model.Stats
{
    public interface IStat
    {
        event Action StateChanged;

        string Name { get; }
        int Value { get; }
        int MaxValue { get; }
    }
}