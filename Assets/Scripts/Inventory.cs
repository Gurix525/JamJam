using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Stack<Item> _items;

    public void AddItemToStack(Item item)
    {
        _items.Push(item);
        Debug.Log($"Item added to stack is: {item.Name}");
    }

    public void RemoveItemFromStack(Item item)
    {
        _items.Pop();
        Debug.Log($"Item removed from stack is: {item.Name}");
    }
}
