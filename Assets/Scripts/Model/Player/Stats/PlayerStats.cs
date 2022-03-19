using System;
using System.Collections;
using System.Collections.Generic;
using Player.Stats;
using UnityEngine;

[Serializable]
public class PlayerStats
{
    [SerializeField] private Health _health;
    [SerializeField] private Armor _armor;
    public Health Health => _health;
    public Armor Armor => _armor;
}
