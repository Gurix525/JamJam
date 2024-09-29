using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public SceneAsset SceneToLoad;

    public Image Fade;

    private float alpha = 0f;
    private float fade;

    private void Start()
    {
        FadeIn();
    }

    private void Update()
    {
        if (fade != 0)
        {
            alpha += (Time.deltaTime/2f) * fade;

            if (fade < 0)
            {
                SetFadeAlpha(1+alpha);
            }
            else
            {
                SetFadeAlpha(alpha);
            }

            if (alpha > 1f || alpha < -1f)
            {
                EndFade();
            }
        }
    }

    private void EndFade()
    {
        fade = 0;
        math.clamp(alpha, 0f, 1f);
        Fade.raycastTarget = false;
    }

    IEnumerator LoadSceneSequence()
    {
        FadeOut();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneToLoad.name, LoadSceneMode.Single);
        StopAllCoroutines();
    }
    public void LoadScene()
    {
        StartCoroutine(LoadSceneSequence());
    }

    public void FadeIn()
    {
        Fade.raycastTarget = true;
        alpha = .2f;
        fade = -1f;
    }
    public void FadeOut()
    {
        Fade.raycastTarget = true;
        alpha = 0f;
        fade = 1f;
    }

    private void SetFadeAlpha(float alpha)
    {
        Fade.color = new Color(Fade.color.r, Fade.color.g, Fade.color.b, alpha);
  
    }

    public void Quit() => Application.Quit();
}
