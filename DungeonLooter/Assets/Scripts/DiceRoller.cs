using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    void Awake() => instance = this;
    public static DiceRoller instance;
    List<Roll> rolls = new List<Roll>();
    public void AddRoll(Die die, int amount) => rolls.Add(new Roll(die, amount));
    public void AllRoll()
    {

    }
}
public struct Roll
{
    public Roll(Die die, int amount)
    {
        this.die = die;
        this.amount = amount;
    }
    public Die die;
    public int amount;
}