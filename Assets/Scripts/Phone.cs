using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactable
{
    [SerializeField] private GameObject _messagesPanel;
    [SerializeField] private float _minCooldownTime, _maxCoodlownTime;

    [SerializeField] private float _cooldownTime, _waitTime, _maxWaitTime;
    private bool _answeredCall;

    private void Awake()
    {
        _messagesPanel = FindObjectOfType<MessagePanel>().gameObject;
    }

    private void Start()
    {
        _waitTime = _maxWaitTime;
        _cooldownTime = Random.Range(_minCooldownTime, _maxCoodlownTime);
        //Interact();
    }

    private void FixedUpdate()
    {
        if (_answeredCall && _cooldownTime >= 0)
        {
            _waitTime = _maxWaitTime;

            _cooldownTime -= Time.deltaTime;
        }

        if (_waitTime > 0)
        {
            _waitTime -= Time.deltaTime;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_answeredCall)
        {
            Interact();
        }

        if (_waitTime == _maxWaitTime || !_answeredCall)
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
    }

    public void PostNotAnsweredCall()
    {
        Debug.Log("Call wasn't answered. ");

    }

    public override void Interact()
    {
        _answeredCall = true;
        _messagesPanel.GetComponent<EmergencyMessageGenerator>().GenerateItemList();

        _cooldownTime = Random.Range(_minCooldownTime, _maxCoodlownTime + 1);
    }
}
