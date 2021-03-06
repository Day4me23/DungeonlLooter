public abstract class Bonus
{
    public Rarity rarity;
}

public class BonusStat: Bonus
{
    public StatType type;
    public int amount;
}

public class BonusDMG: Bonus
{
    public DamageType damageType;
    public Resistance resistance;
}
public enum DamageType { melee, fire, poison, cold, lightning, radiant, necrotic }
public enum Resistance { resistant, vulnerable, immune, heal }

public class BonusAbility: Bonus
{
    public Ability ability;
    public int amount;
    public BonusAbility(Ability ability, int amount)
    {
        this.ability = ability;
        this.amount = amount;
    }
}
public enum Ability { none, fireball }

public class BonusMisc: Bonus
{
    public MiscBonus type;
    public int amount;
}
public enum MiscBonus { bonus }
public enum Rarity { curse, common, uncommon, rare, epic, legendary, special }