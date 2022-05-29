
public class Armor : Equipment
{
    public int armor;
    public Armor(string name, EquipmentType type, BonusAbility ability)
    {
        this.name = name;
        this.type = type;
        this.ability = ability;
    }
}