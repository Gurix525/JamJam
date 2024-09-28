using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactable
{
    [SerializeField] private GameObject _messagesPanel;
    [SerializeField] private float _minCooldownTime, _maxCoodlownTime;

    [SerializeField] private float _cooldownTime, _waitTime, _maxWaitTime;
    private bool _answeredCall, _waitingForAnswer;

    private void Awake()
    {
        _messagesPanel = FindObjectOfType<MessagePanel>().gameObject;
    }

    private void Start()
    {
        _waitTime = _maxWaitTime;
        //Interact();
    }

    private void FixedUpdate()
    {
        if (_answeredCall && _cooldownTime >= 0)
        {
            _waitTime = _maxWaitTime;

            _cooldownTime -= Time.deltaTime;
        }

        if (_waitTime > 0 && _messagesPanel.transform.childCount < 3)
        {
            _waitTime -= Time.deltaTime;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (_cooldownTime <= 0 || !_waitingForAnswer))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            _messagesPanel.GetComponent<MessagePanel>().RemoveMessage();

        if (!_waitingForAnswer)
        {
            Debug.Log("Call");
            CreateCall();
        }

        if (_waitTime <= 0)
        {
            _answeredCall = false;
            _cooldownTime = Random.Range(_minCooldownTime, _maxCoodlownTime);
            _waitTime = _maxWaitTime;
            PostNotAnsweredCall();
        }
    }

    public void CreateCall()
    {
        Debug.Log("Calling...");
        _waitingForAnswer = true;
    }

    public void PostNotAnsweredCall()
    {
        Debug.Log("Call wasn't answered. ");
        _answeredCall = false;
        _waitingForAnswer = false;
    }

    public override void Interact()
    {
        _answeredCall = true;
        _messagesPanel.GetComponent<EmergencyMessageGenerator>().GenerateItemList();

        _cooldownTime = Random.Range(_minCooldownTime, _maxCoodlownTime + 1);
    }

    public void PostCallAnswered()
    {
        _answeredCall = false;
        _waitingForAnswer = false;
    }
}
