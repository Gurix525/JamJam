using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Truck : Interactable
{
    public event EventHandler<bool> TruckSentOff;

    private Inventory _inventory;

    [field: SerializeField]
    public int Number { get; private set; }

    public Message Message { get; private set; }

    public List<GameObject> Items { get; } = new();

    public bool IsTaken { get; private set; }

    public float MaxTimer { get; private set; }

    public float Timer { get; private set; }

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    private void FixedUpdate()
    {
        if (IsTaken)
        {
            Timer += Time.fixedTime;
        }
        if (Timer >= MaxTimer)
        {
            UnTake();
        }
    }

    public override void Interact()
    {
        TryDropItemOnTruck();
        TrySendTruckOff();
    }

    private void TrySendTruckOff()
    {
        if (Items.Count == Message.AllItems.Count())
        {
            SendTruckOff();
        }
    }

    private void TryDropItemOnTruck()
    {
        GameObject item = _inventory.RemoveItemFromStack();
        if (item != null)
        {
            Items.Add(item);
        }
    }

    private void SendTruckOff()
    {
        var messageList = Message.AllItems.OrderBy(item => item.GetComponent<Item>().Name);
        var truckList = Items.OrderBy(item => item.GetComponent<Item>().Name);
        TruckSentOff?.Invoke(this, messageList == truckList);
        Items.Clear();
    }

    public void Take(Message message)
    {
        Timer = 0f;
        IsTaken = true;
        gameObject.SetActive(true);
        Message = message;
    }

    public void UnTake()
    {
        IsTaken = false;
        gameObject.SetActive(false);
    }
    
}