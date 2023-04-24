using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDownStairs : MonoBehaviour
{
    [SerializeField] private TimeLineDownStairs _active;
    [SerializeField] private GameObject _triigerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _active.ActiveTimeLine();
        _triigerUp.SetActive(false);
    }
}
