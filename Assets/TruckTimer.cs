using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TruckTimer : MonoBehaviour
{
    [SerializeField]
    private Truck truck;
    private Image _image;
    
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _image.fillAmount = 1 - truck.Timer / truck.MaxTimer;
    }
}
