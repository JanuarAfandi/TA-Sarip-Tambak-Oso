using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UIFade : MonoBehaviour
{
    public enum Type { FadeIn, FadeOut }

    public float fadeDuration = 1f; // Duration of the fade effect in seconds
    public float fadeDelay = 0f; // Delay before starting the fade effect
    public bool fadeOnStart = true; // Whether to fade in on start
    public Type type = Type.FadeIn;

    public CanvasGroup canvasGroup;

    public UnityEvent onCompleted = new UnityEvent();

    void Start()
    {
        if (fadeOnStart)
        {
            if (type == Type.FadeIn)
                FadeIn();

            if (type == Type.FadeOut)
                FadeOut();
        }
    }

    public void FadeIn()
    {
        StartCoroutine(FadeDelayed(0f, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeDelayed(1f, 0f));
    }

    IEnumerator FadeDelayed(float startAlpha, float targetAlpha)
    {
        yield return new WaitForSeconds(fadeDelay);

        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;

        onCompleted.Invoke();
    }
}
