using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuff
{
    public Equipment head;
    public Equipment chest;
    public Equipment legs;
    public Equipment feet;
    public Equipment hand1;
    public Equipment hand2;
    public Equipment misc1;
    public Equipment misc2;
    public Stuff()
    {
        head = null;
        chest = null;
        legs = null;
        feet = null;
    }
    public bool Equip(Equipment equipment)
    {
        switch (equipment.type)
        {
            case EquipmentType.head:
                if (head != null) 
                    TeamEditor.instance.team.inventory.AddItem(head);
                head = equipment;
                break;
            case EquipmentType.chest:
                //if (chest != null || chest.name != "")
                    //TeamEditor.instance.team.inventory.AddItem(chest);
                chest = equipment;
                break;
            case EquipmentType.legs:
                //if (legs != null || legs.name != "")
                    //TeamEditor.instance.team.inventory.AddItem(legs);
                legs = equipment;
                break;
            case EquipmentType.feet:
                //if (feet != null || feet.name != "")
                    //TeamEditor.instance.team.inventory.AddItem(feet);
                feet = equipment;
                break;
            case EquipmentType.hand:

                break;
            case EquipmentType.misc:

                break;
        }
        Debug.Log("Equiping " + equipment.name + "!");
        return true;
    }
}
