using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    public int damage;
    public int ammoAmount;

    public override void Use()
    {
        base.Use();
        //equip the item
        EquipmentManager.instance.Equip(this);

        RemoveFromInventory();//remove it from the inventory

    }
    
}

public enum EquipmentSlot { Weapon, Resource }
