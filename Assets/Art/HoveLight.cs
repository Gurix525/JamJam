using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveLight : MonoBehaviour
{
    public Light hoverLight;
    public float maxLightIntensity = 1f;
    public float enterLerpSpeed = 5f;
    public float exitLerpSpeed = 3f;

    private float currentIntensity = 0f;
    private float targetIntensity = 0f;
    private float currentLerpSpeed;

    private void Start()
    {
        if (hoverLight != null)
        {
            hoverLight.enabled = false;
            currentIntensity = 0f;
        }
        currentLerpSpeed = exitLerpSpeed;
    }

    private void Update()
    {
        currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, Time.deltaTime * currentLerpSpeed);

        if (hoverLight != null)
        {
            hoverLight.intensity = currentIntensity;
            hoverLight.enabled = currentIntensity > 0.01f;
        }
    }

    private void OnMouseEnter()
    {
        targetIntensity = maxLightIntensity;
        currentLerpSpeed = enterLerpSpeed;
    }

    private void OnMouseExit()
    {
        targetIntensity = 0f;
        currentLerpSpeed = exitLerpSpeed;
    }
}
