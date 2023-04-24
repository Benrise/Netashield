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

    private Transform target;

    private void Awake()
    {
        target = GameObject.FindWithTag("Enemy").transform;
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
            _deadAim.SetTrigger("isDeadRobot");
        }
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
