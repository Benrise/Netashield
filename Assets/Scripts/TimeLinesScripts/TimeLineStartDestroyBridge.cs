using UnityEngine;
using UnityEngine.Playables;

public class TimeLineStartDestroyBridge : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _collider;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Trigger _enable;
    private PlayableDirector _timeLine;

    void Start()
    {
        _timeLine = GetComponent<PlayableDirector>();
    }

    public void ActiveTimeLine()
    {
        _timeLine.Play();
        _gameObject.SetActive(false);
    }
}
 