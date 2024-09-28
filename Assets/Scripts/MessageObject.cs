using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MessageObject
{
    public MessageObject(List<Item> items, List<int> amounts)
    {
        Items = items;
        Amounts = amounts;
    }


    public List<Item> Items = new List<Item>();
    public List<int> Amounts = new List<int>();

}
