using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackEnemy : MonoBehaviour
{
    [SerializeField] private float dist;
    [SerializeField] private EnemyHarassment _scriptEnemy;
    [SerializeField] private Animator _enemy;
    [SerializeField] private GameObject _icon;
    [SerializeField] private bool isCheckHack;
    [SerializeField] private float _timeHack;
    [SerializeField] private float _maxTimeHack;
    [SerializeField] private Sprite _iconHack;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Animator _deadAim;

    [SerializeField] private AudioSource _deactivateEffect;
    [SerializeField] private AudioSource _deactivateSay;

     [SerializeField] private AudioSource _sayToRemove;

    private Transform target;

    private void Awake()
    {
        target = GameObject.FindWithTag("Enemy").transform;
        StartCoroutine(Say());
    }


    public IEnumerator Say(){
        while (true)
        {
            _sayToRemove.Play();

            float delay = Random.Range(3, 10);

            yield return new WaitForSeconds(delay);
        }
    }


    private void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        CheckDistance(distance);
    }


    private void Timer()
    {
        _timeHack -= Time.deltaTime;
        _iconImage.fillAmount = _timeHack / _maxTimeHack;

        if (_timeHack <= 0)
        {
            _scriptEnemy.enabled = false;
            //_enemy.enabled = false;
            _iconImage.GetComponent<Image>().sprite = _iconHack;
            _iconImage.fillAmount = 1;
            Destroy(_sayToRemove);
            _deactivateEffect.Play();
            StartCoroutine(DeactivateRobot());
            _deadAim.SetTrigger("isDeadRobot");
            StopCoroutine(Say());
        }
    }

    IEnumerator DeactivateRobot()
    {
        _deactivateSay.Play();

        yield return new WaitForSeconds(0.5f);
    }

    private void CheckDistance(float distance)
    {
        if (distance <= dist)
        {
            _icon.SetActive(true);

            if (Input.GetButtonDown(GlobalStringVars.FIRE1))
            {
                isCheckHack = true;
            }
        }

        else if (distance > dist)
        {
            _icon.SetActive(false);
        }

        if (Input.GetButtonUp(GlobalStringVars.FIRE1))
        {
            isCheckHack = false;
        }

        if (distance > dist || !isCheckHack)
        {
            _timeHack = _maxTimeHack;
            target.GetComponent<Renderer>().material.color = Color.white;
            _iconImage.fillAmount = 1;
        }


        if (isCheckHack)
        {
            Timer();
        }
    }
}
