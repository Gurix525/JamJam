using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int _maxInventoryAmount = 4;

    private Stack<GameObject> _items = new();
    private PlayerMovement _playerMovement;

    public delegate void OnInventoryChange();
    public event OnInventoryChange onInventoryChangeCallback;
    public int ItemsCount => _items.Count;

    public bool CanTakeAdditionalIten => ItemsCount < _maxInventoryAmount;

    public void Start()
    {
        _playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        onInventoryChangeCallback += _playerMovement.UpdateSpeed;
    }

    public void AddItemToStack(GameObject item)
    {
        _items.Push(item);
        Debug.Log($"Item added to stack is: {item.name}");
        onInventoryChangeCallback?.Invoke();
    }

    public GameObject RemoveItemFromStack()
    {
        GameObject item = _items.Pop();
        Debug.Log($"Item removed from stack is: {item.name}");
        onInventoryChangeCallback?.Invoke();
        return item;
    }

    public float GetStackLen()
    {
        return _items.Count;
    }
}
