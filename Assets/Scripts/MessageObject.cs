using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class MessageObject
{
    public MessageObject(List<Item> items, List<int> amounts, Truck truck)
    {
        Items = items;
        Amounts = amounts;
        Truck = truck;
        Truck.Take();
    }
    public void Check()
    {
        List<Item> truckItems = new List<Item>();
        foreach (GameObject go in Truck.GetItems())
        {
            Item item = go.GetComponent<Item>();
            if (item != null)
            {
                truckItems.Add(item);
            }
        }
        Items = Items.OrderBy(i => i.name).ToList();
        truckItems = truckItems.OrderBy(i => i.name).ToList();

        if (truckItems == Items)
        {
            Truck.Good();
        }
        else
        {
            Truck.Bad();
        }
    }

    
    public string Message;
    public List<Item> Items = new List<Item>();
    public List<int> Amounts = new List<int>();
    public Truck Truck = new Truck();
}
