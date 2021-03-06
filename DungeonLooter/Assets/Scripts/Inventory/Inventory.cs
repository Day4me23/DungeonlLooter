using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class Inventory
{
    int currency;
    public List<Item> items = new List<Item>();
    public void AddItem(Item item)
    {
        items.Add(item);
        DestroyInventorySlots();
        CreateInventorySlot();
    }
    public void SortByName() => items = items.OrderBy(i => i.name).ToList(); 
    public void SortByValue() => items = items.OrderBy(i => i.value).ToList();
    public void SortByLevel() => items = items.OrderBy(i => i.level).ToList();
    public void EquipItem(int index)
    {
        Equipment equipment = items[index] as Equipment;
        Adventurer selected = TeamEditor.instance.selected;

        if (!equipment.Criteria(selected))
            return;

        selected.stuff.Equip(equipment);
        items.RemoveAt(index);

        DestroyInventorySlots();
        CreateInventorySlot();
    }
    public void RemoveItem(int index)
    {
        items.RemoveAt(index);
    }

    void CreateInventorySlot()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject gameObject = new GameObject("InventorySlot", typeof(Image), typeof(InventorySlot));
            gameObject.transform.SetParent(TeamEditor.instance.inventorySlots);
            gameObject.GetComponent<InventorySlot>().Set(i, this);
        }
    }
    void DestroyInventorySlots()
    {
        foreach (Transform child in TeamEditor.instance.inventorySlots)
            GameObject.Destroy(child.gameObject);
    }
}
