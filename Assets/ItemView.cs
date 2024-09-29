using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField]
    private GameObject _currentHeldObject;

    public void Disable()
    {
        Destroy(_currentHeldObject);
        gameObject.SetActive(false);
    }

    public void Enable(GameObject viewPrefab)
    {
        if (_currentHeldObject != null)
        {
            _currentHeldObject.SetActive(false);
            Destroy(_currentHeldObject);
        }
        gameObject.SetActive(true);
        _currentHeldObject = Instantiate(viewPrefab, transform);
    }
}
