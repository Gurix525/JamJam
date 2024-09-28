using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageView : MonoBehaviour
{
    [SerializeField] private Message _message;
    [SerializeField] private TMPro.TMP_Text _number;
    [SerializeField] private TMPro.TMP_Text _text;

    internal void UpdateMessage(int number, Message message)
    {
        _number.text = number.ToString();
        _text.text = message.Text;
    }
}
