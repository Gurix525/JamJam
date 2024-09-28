using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Stack<GameObject> _items = new();

    public void AddItemToStack(GameObject item)
    {
        _items.Push(item);
        Debug.Log($"Item added to stack is: {item.name}");
    }

    public void RemoveItemFromStack(GameObject item)
    {
        _items.Pop();
        Debug.Log($"Item removed from stack is: {item.name}");
    }
}
