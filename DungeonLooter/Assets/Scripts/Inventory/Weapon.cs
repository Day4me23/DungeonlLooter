
public class Weapon : Equipment
{
    public int damage;
    public Weapon(string name, EquipmentType type, BonusAbility ability)
    {
        this.name = name;
        this.type = type;
        this.ability = ability;
    }
}
