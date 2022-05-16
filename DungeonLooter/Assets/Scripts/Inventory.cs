using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }
    public static Inventory instance;
    #endregion

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
