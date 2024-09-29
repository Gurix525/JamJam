using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TruckTimer : MonoBehaviour
{
    private GameObject _parent;
    private Truck _grandParentTruck;
    private Image _image;
    
    void Start()
    {
        _parent = transform.parent.gameObject;
        _grandParentTruck = _parent.GetComponentInParent<Truck>();
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _image.fillAmount = _grandParentTruck.GetTimer() / _grandParentTruck.GetCooldownTime();
    }
}
