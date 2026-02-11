using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 0.5f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0)
        {
            t -= Time.deltaTime / fadeDuration;
            canvasGroup.alpha = t;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }

    public IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / fadeDuration;
            canvasGroup.alpha = t;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }
}
