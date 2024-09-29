using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Message
{
    public string Text { get; }
    public List<Item> Items { get; } = new();
    public List<int> Amounts { get; } = new();
    public IEnumerable<Item> AllItems
    {
        get
        {
            var list = new List<Item>();
            for (int i = 0; i < Items.Count; i++)
            {
                for (int j = 0; j < Amounts[i]; j++)
                {
                    list.Add(Items[i]);
                }
            }
            return list;
        }
    }
    public Message(List<Item> items, List<int> amounts, string text)
    {
        Items = items;
        Amounts = amounts;
        Text = text;
    }
}