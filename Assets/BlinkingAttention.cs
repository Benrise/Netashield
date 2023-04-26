using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkingAttention : MonoBehaviour
{
    public Image image;
    public float blinkTime = 0.5f; // время одного мигания
    public float startDelay = 0f; // задержка перед началом мигания

    private void Start()
    {
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        Color color = image.color;
        color.a = 1f;
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            color = image.color;
            color.a = 1f;
            image.color = color;
            yield return new WaitForSeconds(blinkTime / 2f);

            color.a = 0.5f;
            image.color = color;
            yield return new WaitForSeconds(blinkTime / 2f);
        }
    }
}
