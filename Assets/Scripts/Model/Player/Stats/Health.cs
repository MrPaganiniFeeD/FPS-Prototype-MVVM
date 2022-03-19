using System;
using Player.Model.Stats;
using UnityEngine;

namespace Player.Stats
{
    [Serializable]
    public class Health : Stat
    {
        public Health(string name, int maxValue) : base(name, maxValue)
        {
        }
        public Health(string name, int currentValue, int maxValue) : base(name, currentValue, maxValue)
        {
        }
    }
}