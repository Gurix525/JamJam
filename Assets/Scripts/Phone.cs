using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactable
{
    [SerializeField] private GameObject _messagesPanel;

    private void Awake()
    {
        _messagesPanel = FindObjectOfType<MessagePanel>().gameObject;
    }

    private void Start()
    {
        Interact();
    }

    public override void Interact()
    {
        _messagesPanel.GetComponent<EmergencyMessageGenerator>().GenerateItemList();
    }
}
