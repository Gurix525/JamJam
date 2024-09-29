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
    public Message(List<Item> items, List<int> amounts, string text)
    {
        Items = items;
        Amounts = amounts;
        Text = text;
    }
}