using System;
using Player.Model.Stats;
using UnityEngine;

namespace Player.Stats
{
    [Serializable]
    public class Armor : Stat
    {
        public Armor(string name, int maxValue) : base(name, maxValue)
        {
        }

        public Armor(string name, int currentValue, int maxValue) : base(name, currentValue, maxValue)
        {
        }
    }
}