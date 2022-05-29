using UnityEngine;
using System.Collections.Generic;


public class Creature
{
    [SerializeField] protected string name;
    [SerializeField] protected Sprite art;

    [SerializeField] protected int level;
    [SerializeField] protected int experience;

    [SerializeField] protected int health;
    [SerializeField] protected int mana;
    [SerializeField] protected int stamina;
    [SerializeField] protected int bonus;
    [SerializeField] protected int initiative;

    public Dictionary<StatType, Stat> stats = new Dictionary<StatType, Stat>();

    public string GetName() => name;
    public int GetLevel() => level;
}