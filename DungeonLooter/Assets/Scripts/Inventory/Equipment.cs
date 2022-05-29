using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Equipment : Item
{
    public int damage;
    public int armor;
    public List<EquipmentRequirement> requirements = new List<EquipmentRequirement>();
    public EquipmentType type;

    public Equipment(string name, int num)
    {
        this.name = name;
        type = (EquipmentType)num;
    }
    

}

public class EquipmentRequirement
{
    int requirement;
    StatType stat;
    
}

public enum EquipmentType {head, chest, legs, feet, hand, misc}