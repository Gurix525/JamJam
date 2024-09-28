using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private MessageObject _messageObject;
    [SerializeField] private TMPro.TMP_Text _text;

    public void SetUpMessageObject(List<Item> items, List<int> amounts)
    {
        _messageObject = new MessageObject(items, amounts);
    }

    public void SetMessageText(string text)
    {
        _text.text = text;
        _messageObject.Message = text;
    }
}
