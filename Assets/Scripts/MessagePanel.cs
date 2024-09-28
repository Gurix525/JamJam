using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
    [SerializeField] private GameObject _messageObject;

    public void CreateMessage(string text)
    {
        Message message = Instantiate(_messageObject.GetComponent<Message>(), transform);

        message.SetMessageText(text);
    }

    public void RemoveMessage(int index = 0)
    {
        Destroy(transform.GetChild(index).gameObject);
    }
}
