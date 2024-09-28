using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Interactable
{
    private List<GameObject> _items;
    private Inventory _inventory;
    private bool _taken = false;

    public List<GameObject> Items => _items;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    public override void Interact()
    {
        _items.Add(_inventory.RemoveItemFromStack());
    }

    public void Good()
    {
        Debug.Log("Good");
    }

    public void Bad()
    {
        Debug.Log("Bad");
    }

    public bool GetTaken()
    {
        return _taken;
    }

    public void Take()
    {
        _taken = true;
    }

    public void UnTake()
    {
        _taken = false;
    }

    public List<GameObject> GetItems()
    {
        return _items;
    }
}