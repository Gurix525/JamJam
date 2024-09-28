using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Interactable
{
    private List<GameObject> _items;
    private Inventory _inventory;

    public List<GameObject> Items => _items;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    public override void Interact()
    {
        _items.Add(_inventory.RemoveItemFromStack());
    }
}