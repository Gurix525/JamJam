using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int _maxInventoryAmount = 4;

    private Stack<GameObject> _items = new();

    public int ItemsCount => _items.Count;

    public bool CanTakeAdditionalIten => ItemsCount < _maxInventoryAmount;

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
