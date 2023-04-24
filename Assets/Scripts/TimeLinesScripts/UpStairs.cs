using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class UpStairs : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _collider;
    private PlayableDirector _timeLine;

    void Start()
    {
        _timeLine = GetComponent<PlayableDirector>();
    }

    public void ActiveTimeLine()
    {
        _timeLine.Play();
    }
}
