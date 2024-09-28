using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessagePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private MessageObject _messageObject = new();

    public void SetMessage(string message)
    {
        _text.text = message;
    }

    public void SetUpMessageObject(List<Item> items, List<int> amounts)
    {
        _messageObject.Items = items;
        _messageObject.Amounts = amounts;
    }
}
