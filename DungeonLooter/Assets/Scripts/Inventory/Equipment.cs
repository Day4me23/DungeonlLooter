using System.Collections.Generic;
public class Equipment : Item
{
    public BonusAbility ability;
    public List<Bonus> bonus = new List<Bonus>();
    public List<Requirement> requirements = new List<Requirement>();
    public EquipmentType type;

    public void Equip()
    {

    }
    public void Unequip()
    {

    }
    public bool Criteria(Adventurer player)
    {
        for (int i = 0; i < requirements.Count; i++)
        {
            if (requirements[i].GetType() == typeof(RequireStat))
            {
                if (((RequireStat)requirements[i]).requirement > player.stats[((RequireStat)requirements[i]).stat].GetMax())
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

public enum EquipmentType {head, chest, legs, feet, hand, misc}