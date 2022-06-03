using UnityEngine;
using System.Collections.Generic;

public static class Dice
{
    public static int ShowRoll(List<Die> dice, int mod)
    {
        int result = mod;
        foreach(Die die in dice)
            result += ShowRoll(die);

        try { DiceRoller.instance.AllRoll(); }
        catch { Debug.LogWarning("Dice roller not found"); }

        return result;
    }
    public static int ShowRoll(Die die, int count, int mod)
    {
        int result = mod;
        for (int i = 0; i < count; i++)
            result += ShowRoll(die);

        try { DiceRoller.instance.AllRoll(); }
        catch { Debug.LogWarning("Dice roller not found"); }

        return result;
    }
    static int ShowRoll(Die die)
    {
        int result = Random.Range(0, (int)die) + 1;

        try { DiceRoller.instance.AddRoll(die, result); }
        catch { Debug.LogWarning("Dice roller not found"); }

        return result;
    }
    public static int HideRoll(Die die, int mod)
    {
        int result = Random.Range(0, (int)die) + 1;
        return result + mod;
    }
}

public enum Die { d4 = 4, d6 = 6, d8 = 8, d10 = 10, d12 = 12, d20 = 20, d100 = 100 }