using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature: ScriptableObject
{
    [SerializeField] new string name;
    [SerializeField] int level;
    [SerializeField] int experience;

    [SerializeField] int health;
    [SerializeField] int mana;
    [SerializeField] int stamina;
    [SerializeField] int bonus;
    [SerializeField] int initiative;

    [SerializeField] Stat str;
    [SerializeField] Stat dex;
    [SerializeField] Stat con;
    [SerializeField] Stat mag;
    [SerializeField] Stat luck;
}