using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : Creature
{
    public Stuff stuff;
    

    public Player(string name, int [] stats, List<Equipment> equipment)
    {
        this.name = name;

        for (int i = 0; i < System.Enum.GetNames(typeof(StatType)).Length; i++)
            this.stats.Add((StatType)i, new Stat(stats[i]));
        
        for (int i = 0; i < equipment.Count; i++)
            stuff.Equip(equipment[i]);

        stuff = new Stuff();
    }
}
