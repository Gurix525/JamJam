using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Interactable
{
    private List<GameObject> _items = new List<GameObject>();
    private Inventory _inventory;
    private bool _taken = false;

    public List<GameObject> Items => _items;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    public override void Interact()
    {
        GameObject item = _inventory.RemoveItemFromStack();
        if (item != null)
        {
            _items.Add(item);
        }
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