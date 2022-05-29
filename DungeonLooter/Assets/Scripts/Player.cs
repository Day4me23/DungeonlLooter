using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : Creature
{
    public Stuff stuff;
    

    public Player(string name, int str, int dex, int con, int mag, int luck, List<Equipment> equipment)
    {
        this.name = name;
        this.str =  new Stat(str);
        this.dex =  new Stat(dex);
        this.con =  new Stat(con);
        this.mag =  new Stat(mag);
        this.luck =  new Stat(luck);
        
        for (int i = 0; i < equipment.Count; i++)
            stuff.Equip(equipment[i]);
        stuff = new Stuff();
    }
}
