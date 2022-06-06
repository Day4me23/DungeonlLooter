using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Creature
{
    [SerializeField] protected string name;
    [SerializeField] protected Sprite art;

    [SerializeField] protected int level;
    [SerializeField] protected int experience;

    [SerializeField] protected int health;
    [SerializeField] protected int stamina;
    [SerializeField] protected int mana;
    [SerializeField] protected int bonus;

    [SerializeField] protected int turn;

    // Change public to private and fix errors that come after
    public Dictionary<StatType, Stat> stats = new Dictionary<StatType, Stat>();
    protected List<BonusDMG> bonusDMG = new List<BonusDMG>();
    
    
    #region Get Methods
    public string GetName() => name;
    public int GetHealth() => health;
    public int GetStamina() => stamina;
    public int GetMana() => mana;
    public int GetLevel() => level;
    public int GetTurn() => turn;

    // All methods under this line must be balanced properly
    public float GetMaxHealth() => stats[StatType.constitution].GetMax();
    public float GetMaxStamina() => stats[StatType.dexterity].GetMax();
    public float GetMaxMana() => stats[StatType.magic].GetMax();
    public int GetInitiative() => Mathf.FloorToInt(stats[StatType.dexterity].GetMax() / 10);
    public int GetDamage() => 10;
    #endregion
    #region Set Methods
    public void SetTurn(int turn) => this.turn = turn;
    #endregion


    public void Damage(int amount, DamageType damageType)
    {
        // balence this!!!
        int damage = amount;

        for (int i = 0; i < bonusDMG.Count; i++)
            if (bonusDMG[i].damageType == damageType)
            {
                if (bonusDMG[i].resistance == Resistance.resistant)
                {
                    damage /= 2;
                    goto Damage;
                }
                if (bonusDMG[i].resistance == Resistance.immune)
                {
                    damage = 0;
                    goto Damage;
                }
                if (bonusDMG[i].resistance == Resistance.vulnerable)
                {
                    damage *= 2;
                    goto Damage;
                }
            }

        Damage: health -= damage;
    }
    public void Heal(int amount)
    {
        health += amount;
    }
}