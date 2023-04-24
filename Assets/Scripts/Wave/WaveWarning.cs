using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveWarning : MonoBehaviour
{
    [SerializeField] private GameObject _colorWarningYellow;
    [SerializeField] private GameObject _colorWarningRed;
    public float currentTime;
    [SerializeField] private float _timer;

    private void Update()
    {
        _timer -= Time.deltaTime;
        currentTime = _timer;

        if (_timer <= 7)
        {
            _colorWarningYellow.SetActive(true);
        }

        if (_timer <= 3)
        {
            _colorWarningRed.SetActive(true);
        }

        if (_timer <= 0)
        {
            currentTime = 0;
        }
        
    }

}
