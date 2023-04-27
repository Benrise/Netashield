using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingAttention : MonoBehaviour
{
    public Image image;
    public float blinkTime = 0.5f; // время одного мигания
    public float startDelay = 0f; // задержка перед началом мигания

    private WaveSpawner _waveSpawner;


    private void Update()
    {
        if (_waveSpawner.IsLevelEnd)
        {
            Debug.Log("Stop!");
            StopCoroutine(Blink());
        }
    }
    private void Start()
    {
        _waveSpawner = WaveSpawner.Instance;
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;
        if (!_waveSpawner.IsLevelEnd)
        {
            Debug.Log("Start!");
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        Color color = image.color;
        color.a = 1f;
        yield return new WaitForSeconds(startDelay);

        while (!_waveSpawner.IsLevelEnd)
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
