using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : Creature
{
    public Enemy(string name, int[] stats)
    {
        this.name = name;

        for (int i = 0; i < System.Enum.GetNames(typeof(StatType)).Length; i++)
            this.stats.Add((StatType)i, new Stat(stats[i]));

        health = (int)GetMaxHealth();
        mana = (int)GetMaxMana();
        stamina = (int)GetMaxStamina();
    }
}
