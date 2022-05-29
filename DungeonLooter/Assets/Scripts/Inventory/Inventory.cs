using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public void EquipItem(int index)
    {
        TeamEditor.instance.GetStuff().Equip((Equipment)items[index]);
        items.RemoveAt(index);
        DestroyInventorySlots();
        CreateInventorySlot();
    }
    public void RemoveItem(Item item)
    {

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
