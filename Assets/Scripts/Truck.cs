using System.Collections.Generic;
using UnityEngine;

public class Truck : Interactable
{
    private Inventory _inventory;

    [field: SerializeField]
    public int Number { get; private set; }

    public Message Message { get; private set; }

    public List<GameObject> Items { get; } = new();

    public bool IsTaken { get; private set; }

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    public override void Interact()
    {
        GameObject item = _inventory.RemoveItemFromStack();
        if (item != null)
        {
            Items.Add(item);
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

    public void Take(Message message)
    {
        IsTaken = true;
        gameObject.SetActive(true);
        Message = message;
    }

    public void UnTake()
    {
        IsTaken = false;
    }
}