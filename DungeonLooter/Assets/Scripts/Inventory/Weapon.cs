using UnityEngine;

public class Weapon : Equipment
{
    public Die die;
    public WeaponType weaponType;
    public Weapon(string name, WeaponType weaponType, Sprite art, Die die)
    {
        this.type = EquipmentType.hand;
        this.name = name;
        this.weaponType = weaponType;
        this.art = art;
        this.die = die;
    }
}

public enum WeaponType { Melee, Range, Magic }
