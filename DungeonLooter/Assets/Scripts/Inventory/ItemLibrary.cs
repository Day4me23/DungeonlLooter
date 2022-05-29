using UnityEngine;

public static class ItemLibrary
{
    public static Item[] items = new Item[]
    {
        new Armor("Leather helmet", EquipmentType.head, null),
        new Armor("Leather Chest", EquipmentType.chest, null),
        new Armor("Leather pants", EquipmentType.legs, null),
        new Armor("Leather boots", EquipmentType.feet, null),
        new Armor("Plate helmet", EquipmentType.head, null),
        new Armor("Plate Chest", EquipmentType.chest, null),
        new Armor("Plate pants", EquipmentType.legs, null),
        new Armor("Plate boots", EquipmentType.feet, null)
    };

    public static Item GetRandomItem() => items[Random.Range(0,items.Length)];
}
