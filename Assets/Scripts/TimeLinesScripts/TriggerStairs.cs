using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStairs : MonoBehaviour
{
    [SerializeField] private UpStairs _active;
    [SerializeField] private GameObject _triggerDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _active.ActiveTimeLine();
        _triggerDown.SetActive(false);
    }
}
