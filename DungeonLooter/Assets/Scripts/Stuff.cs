using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stuff
{
    public Equipment head;
    public Equipment chest;
    public Equipment leg;
    public Equipment feet;
    public Equipment hand1;
    public Equipment hand2;
    public Equipment misc1;
    public Equipment misc2;
    
    public bool Equip(Equipment equipment)
    {
        Debug.Log("Equiping " + equipment.name);
        return true;
    }
}
