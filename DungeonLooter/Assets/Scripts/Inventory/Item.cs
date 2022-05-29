using UnityEngine;
public class Item
{
    public string name;
    public Sprite art;
    public Rarity rarity;
    public int value;
}
public enum Rarity { curse, common, uncommon, rare, epic, legendary, special }