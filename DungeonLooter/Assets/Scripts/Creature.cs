using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Creature
{
    [SerializeField] protected new string name;
    [SerializeField] protected int level;
    [SerializeField] protected int experience;

    [SerializeField] protected int health;
    [SerializeField] protected int mana;
    [SerializeField] protected int stamina;
    [SerializeField] protected int bonus;
    [SerializeField] protected int initiative;

    [SerializeField] protected Stat str;
    [SerializeField] protected Stat dex;
    [SerializeField] protected Stat con;
    [SerializeField] protected Stat mag;
    [SerializeField] protected Stat luck;
}