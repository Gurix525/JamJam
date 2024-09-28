using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
    [SerializeField] private MessageObject _messageObject;
    [SerializeField] private TMPro.TMP_Text _text;

    public void SetUpMessageObject(List<Item> items, List<int> amounts, Truck truck)
    {
        _messageObject = new MessageObject(items, amounts, truck);
    }

    public void SetMessageText(string text)
    {
        _text.text = text;
        _messageObject.Message = text;
    }

    public void RemoveMessage(int index = 0)
    {
        Destroy(transform.GetChild(index).gameObject);
    }
}
