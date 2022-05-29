using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{ 
    private int start;

    public Stat(int start)
    {
        this.start = start;
    }
    public int GetTotal() => start;
}

public enum StatType {strength, dexterity, constitution, magic, luck}
