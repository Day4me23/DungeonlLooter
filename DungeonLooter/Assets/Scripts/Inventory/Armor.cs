using UnityEngine;
public class Armor : Equipment
{
    public int armor;
    public Armor(string name, EquipmentType type, Sprite art)
    {
        this.name = name;
        this.type = type;
        this.art = art;
    }
}