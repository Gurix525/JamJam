using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class EmergencyMessageGenerator : MonoBehaviour
{
    [SerializeField] private Item[] _itemPrefabs;

    public Message GenerateMessage()
    {
        List<Item> selectedItems = new();
        List<Item> shuffledItems = _itemPrefabs.Shuffle().ToList();
        List<int> amounts = new();
        int randomItemsCount = new System.Random().Next(1, 2);
        for (int i = 0; i < randomItemsCount; i++)
        {
            selectedItems.Add(shuffledItems[i]);
            amounts.Add(new System.Random().Next(1, 3));
        }
        return CreateMessage(selectedItems, amounts);
    }

    public Message CreateMessage(List<Item> items, List<int> amounts)
    {
        string result = "", list = "";
        int i = 0;
        foreach (Item item in items)
        {
            result = i == 0 ? $"{result}{item.Messages[UnityEngine.Random.Range(0, item.Messages.Length)]}" : $"{result} {item.Messages[UnityEngine.Random.Range(0, item.Messages.Length)]}";
            list += (i > 0 ? "\n" : "") + $"{item.Name}-{amounts[i]}";
            i++;
        }
        return new Message(items, amounts, result + ":\n" + list);
    }
}

public enum Situations
{
    flood,
    fire
}