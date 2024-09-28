using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmergencyMessageGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _messageObject;
    [SerializeField] private Item[] _itemPrefabs;

    [SerializeField] private int _maxItemsAmount;

    public void GenerateItemList()
    {
        List<Item> itemList = new List<Item>();
        Array values = Enum.GetValues(typeof(Situations));

        Situations situation = (Situations)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        Debug.Log($"Sytuacja {situation}");

        int chosenItemAmount = UnityEngine.Random.Range(1, _maxItemsAmount + 1);
        List<int> amounts = new List<int>();

        foreach (Item item in _itemPrefabs) 
        {
            Debug.Log($"Iteracja przedmiotu {item.Name}");
            bool situationPasses = false;

            foreach(int element in item.Situations)
            {
                if(element == (int)situation) 
                {
                    Debug.Log("Sytuacja pasuje");
                    situationPasses = true;
                    break;
                }
            }

            if (!situationPasses)
                continue;


            Debug.Log("Wybieram ilo��");
            int chosenAmount = UnityEngine.Random.Range(item.MinAmount, item.MaxAmount);

            if (chosenItemAmount >= chosenAmount)
            {
                Debug.Log($"Ilo�� pasuje: {chosenAmount}");
                chosenItemAmount -= chosenAmount;
                amounts.Add(chosenAmount);
                itemList.Add(item);
            }
            else
                continue;
        }

        CreateMessage(itemList, amounts);
    }

    public void CreateMessage(List<Item> items, List<int> amounts)
    {
        string result = "", list = "";

        int i = 0;
        foreach (Item item in items)
        {
            result = i == 0 ? $"{result}{item.Messages[UnityEngine.Random.Range(0, item.Messages.Length)]}" : $"{result} {item.Messages[UnityEngine.Random.Range(0, item.Messages.Length)]}";
            list += (i > 0 ? "\n" : "") + $"{item.Name}-{amounts[i]}";
            i++;
        }

        Message message = _messageObject.GetComponent<Message>();

        GetComponent<MessagePanel>().CreateMessage(result + ":\n" + list);
        message.SetUpMessageObject(items, amounts);
    }
}

public enum Situations
{
    flood,
    fire
}