using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Equipment : Item
{
    public int damage;
    public int armor;
    public List<Requirement> requirements = new List<Requirement>();
    public EquipmentType type;

    public Equipment(string name, int num)
    {
        this.name = name;
        type = (EquipmentType)num;
    }
    public void Equip()
    {

    }
    public void Unequip()
    {

    }
    public bool Criteria(Player player)
    {
        for (int i = 0; i < requirements.Count; i++)
        {
            if (requirements[i].GetType() == typeof(RequireStat))
            {
                if (((RequireStat)requirements[i]).requirement > player.stats[((RequireStat)requirements[i]).stat].GetTotal())
                    return false;
            }
            if (requirements[i].GetType() == typeof(RequireLevel))
            {
                if (((RequireLevel)requirements[i]).requirement > player.GetLevel())
                    return false;
            }
        }

        return true;
    }
}

public abstract class Requirement
{
    public int requirement;
}
public class RequireStat: Requirement
{
    public StatType stat;
}
public class RequireLevel: Requirement
{

}
public class RequireClass: Requirement
{

}

public enum EquipmentType {head, chest, legs, feet, hand, misc}