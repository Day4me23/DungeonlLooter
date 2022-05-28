using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    int currency;
    List<Item> items = new List<Item>();

    [SerializeField] int slot;
    [SerializeField] Stuff selected;


    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public void EquipItem(Equipment equipment)
    {
        selected.Equip(equipment);
    }
    public void RemoveItem(Item item)
    {

    }
}
