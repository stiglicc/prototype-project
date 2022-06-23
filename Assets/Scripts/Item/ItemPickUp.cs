using System;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp() { 
        Debug.Log("Picking up " + " " + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
