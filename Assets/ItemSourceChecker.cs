using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSourceChecker : MonoBehaviour
{
    private Interactor _interactor;
    private Interactable _interactable;
    private GameObject _sprite;

    public float heightOffset;
    
    void Start()
    {
        _interactor = GameObject.FindObjectOfType<Interactor>().GetComponent<Interactor>();
        _sprite = transform.GetChild(0).gameObject;
        _sprite.SetActive(false);
    }

    void FixedUpdate()
    {
        
        _interactable = _interactor.GetTargetInteractable();
        
        if (Vector3.Distance(_interactable.transform.position, _interactor.transform.position) < _interactor.GetMaxDistance())
        {
            gameObject.transform.position = new Vector3(
                _interactable.transform.position.x,
                _interactable.transform.position.y + heightOffset,
                _interactable.transform.position.z
            );            _sprite.SetActive(true);
        }
        else
        {
            _sprite.SetActive(false);
        }
    }
}
