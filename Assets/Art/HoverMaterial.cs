using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class HoverMaterial : MonoBehaviour
{

    [Space]
    [Header("Iddle")]
    public Outline Iddle;
    [Header("OnHoverEnter")]
    public Outline OnHoverEnter = new Outline { name = OutlineState.OnHoverEnter };
    [Header("ClickOk")]
    public Outline ClickOk = new Outline { name = OutlineState.ClickOk };
    [Header("ClickFailed")]
    public Outline ClickFailed = new Outline { name = OutlineState.ClickNo };

    public CurveField CurveField;


    


    private float currentFloat = 0f;
    private float targetFloat = 0f;
    private float currentLerpSpeed;


    private float currentThickness;
    private Color currentColor;


    private Outline currentOutline;
    private Material TargetMaterial;
    private Material currentMaterial;

    private void Start()
    {
        //Todo get mashine state, respond to state


        Material material = GetComponent<MeshRenderer>().materials[0];

        TargetMaterial = new Material(material);
        GetComponent<MeshRenderer>().materials[0] = TargetMaterial;


        if (TargetMaterial != null) { currentFloat = 0f; }
        else { Debug.LogError("Whers material"); }

        targetFloat = 0f;
        currentFloat = 0f;
        SetOutline(Iddle);
        currentThickness = Iddle.Thickness;
        currentColor = Iddle.Color;
        currentMaterial = GetComponent<MeshRenderer>().materials[0];
    }

    private void Update()
    {
        if (TargetMaterial != null)
        {
            currentFloat = Mathf.Lerp(currentFloat, targetFloat, Time.deltaTime * currentOutline.LerpSpeed);
            UpdateMaterial();
        }
    }



    private void OnMouseEnter()
    {

        SetOutline(OnHoverEnter);
    }

    private void OnMouseExit()
    {
        //Block if was machine was clicked

        SetOutline(Iddle);
    }

    private void OnMouseDown()
    {
        StartCoroutine(AnimateError());
    }

    IEnumerator AnimateError()
    {
        SetOutline(ClickFailed);
        yield return new WaitForSeconds(.3f);
        SetOutline(Iddle);
        currentLerpSpeed = 1f;
        yield return new WaitForSeconds(.2f);
        SetOutline(ClickFailed);
        yield return new WaitForSeconds(1f);
        SetOutline(Iddle);
        StopCoroutine(AnimateError());
    }

    private void SetOutline(Outline outline) { currentOutline = outline; targetFloat = 1f; currentFloat = 0f; }

    private void UpdateMaterial()
    {
        currentThickness = Mathf.Lerp(currentThickness, currentOutline.Thickness, currentFloat);
        currentColor = Color.Lerp(currentColor, currentOutline.Color, currentFloat);

        currentMaterial.SetFloat("_OutlineThickness", currentThickness);
        currentMaterial.SetColor("_OutlineColor", currentColor);

    }

}

[System.Serializable]
public class Outline
{
    public OutlineState name;
    public Color Color;
    public float Thickness;
    public float LerpSpeed;
}

public enum OutlineState { Iddle, OnHoverEnter, OnHoverExit, ClickOk, ClickNo };