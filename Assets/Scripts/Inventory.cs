using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int _maxInventoryAmount = 4;

    private Stack<GameObject> _items = new();
    private PlayerMovement _playerMovement;
    private BalancingSystem _balancingSystem;

    public delegate void OnInventoryChange();
    public event OnInventoryChange onInventoryChangeCallback;
    public int ItemsCount => _items.Count;

    public bool CanTakeAdditionalIten => ItemsCount < _maxInventoryAmount;

    public void Start()
    {
        _balancingSystem = FindObjectOfType<BalancingSystem>();
        _playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        onInventoryChangeCallback += _playerMovement.UpdateSpeed;
        onInventoryChangeCallback += EmptyCheck;
        EmptyCheck();
    }

    public void AddItemToStack(GameObject item)
    {
        _items.Push(item);
        Debug.Log($"Item added to stack is: {item.name}");
        onInventoryChangeCallback?.Invoke();
    }

    public void ClearStack()
    {
        _items.Clear();
        onInventoryChangeCallback?.Invoke();
    }

    public GameObject RemoveItemFromStack()
    {
        if (_items.Count>=1)
        {
            GameObject item = _items.Pop();
            Debug.Log($"Item removed from stack is: {item.name}");
            onInventoryChangeCallback?.Invoke();
            return item;
        }
        else
        {
            return null;
        }
    }

    public float GetStackLength()
    {
        return _items.Count;
    }

    public void EmptyCheck()
    {
        if (_items.Count > 0)
        {
            _balancingSystem.gameObject.SetActive(true);
        }
        else
        {
            _balancingSystem.gameObject.SetActive(false);
        }
    }
}