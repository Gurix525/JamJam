using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactable
{
    [SerializeField] private GameObject _messagesPanel;
    [SerializeField] private float _minCooldownTime, _maxCooldownTime;

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
        if (_cooldownTime > 0)
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
        {
            _messagesPanel.GetComponent<MessagePanel>().RemoveMessage();
        }

        if (!_waitingForAnswer)
        {
            Debug.Log("Call");
            CreateCall();
        }

        if (_waitTime <= 0)
        {
            ResetCallState();
            _cooldownTime = Random.Range(_minCooldownTime, _maxCooldownTime);
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
        Debug.Log("Call wasn't answered.");
        ResetCallState();
    }

    public override void Interact()
    {
        _answeredCall = true;
        _messagesPanel.GetComponent<EmergencyMessageGenerator>().GenerateItemList();
        _cooldownTime = Random.Range(_minCooldownTime, _maxCooldownTime + 1);
    }

    public void PostCallAnswered()
    {
        Debug.Log("Call was answered.");
        ResetCallState();
    }

    private void ResetCallState()
    {
        _answeredCall = false;
        _waitingForAnswer = false;
    }
}
