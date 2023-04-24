using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRope : MonoBehaviour
{
    [SerializeField] private TimeLineRope _active;
    [SerializeField] private GameObject _triggerRope;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _active.ActiveTimeLine();
        _triggerRope.SetActive(false);
    }
}
