using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private ItemView[] _itemViews;

    private void Start()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory)
        {
            inventory.onInventoryChangeCallback += _inventory_onInventoryChangeCallback;
        }
    }

    private void _inventory_onInventoryChangeCallback()
    {
        Item[] items = _inventory.Items.Reverse().ToArray();    
        for (int i = 0; i < 4; i++)
        {
            if (i < items.Length)
            {
                _itemViews[i].Enable(items[i].ViewPrefab);
            }
            else
            {
                _itemViews[i].Disable();
            }
        }
    }
}