using UnityEngine;
using System.Collections.Generic;

public static class ItemLibrary
{
    static string folder = "Inventory/";
    static Sprite Art(string sprite, string image)
    {
        Object[] sprites = Resources.LoadAll(sprite);
        foreach(Object s in sprites)
            if (s.name == image)
                return s as Sprite;
        return null;
    }
    public static Item[] items = new Item[]
    {
        new Armor("Leather helmet", EquipmentType.head,  Art(folder + "1", "LeatherHelmet")),
        new Armor("Leather Chest", EquipmentType.chest,  Art(folder + "1", "LeatherChest")),
        new Armor("Leather pants", EquipmentType.legs,  Art(folder + "1", "LeatherPants")),
        new Armor("Leather boots", EquipmentType.feet,  Art(folder + "1", "LeatherBoots")),
        new Armor("Plate helmet", EquipmentType.head,  Art(folder + "1", "PlateHelmet")),
        new Armor("Plate Chest", EquipmentType.chest,  Art(folder + "1", "PlateChest")),
        new Armor("Plate pants", EquipmentType.legs,  Art(folder + "1", "PlatePants")),
        new Armor("Plate boots", EquipmentType.feet,  Art(folder + "1", "PlateBoots")),

        new Weapon("Longsword", WeaponType.Melee, Art(folder + "1", "Longsword"), Die.d8),
        new Weapon("Dagger", WeaponType.Melee,  Art(folder + "1", "Shortsword"), Die.d4),
        new Weapon("Longbow", WeaponType.Range,  Art(folder + "2", "Longbow"), Die.d8),
        new Weapon("Wand", WeaponType.Magic,  Art(folder + "1", "Wand"), Die.d4),
        new Weapon("Staff", WeaponType.Magic,  Art(folder + "1", "Staff"), Die.d6),

        new Consumeable("HP potion", Art(folder + "2", "PotionHP")),
        new Consumeable("MP potion", Art(folder + "2", "PotionMP"))
    };

    public static Item GetRandomItem()
    {
        int ran = Random.Range(0, items.Length);
        Debug.Log(items[ran].name);
        return items[ran];
    }
    public static Item[] GetItems(int num)
    {
        List<Item> items = new List<Item>();

        for (int i = 0; i < num; i++)
            items.Add(items[Random.Range(0, items.Count)]);

        foreach(Item i in items)
        {
            if (i is Consumeable)
            {
                SetupConsumeable(i as Consumeable);
                items.Add(i);
            }
            if (i is Weapon)
            {
                SetupWeapon(i as Weapon);
                items.Add(i);
            }
            if (i is Armor)
            {
                SetupArmor(i as Armor);
                items.Add(i);
            }
        }

        return items.ToArray();
    }
    static void SetupConsumeable(Consumeable consumeable)
    {

    }
    static void SetupWeapon(Weapon weapon)
    {

    }
    static void SetupArmor(Armor armor)
    {

    }
}
