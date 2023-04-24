using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarassment : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speedMove;
    [SerializeField] private float dist;
    [SerializeField] private float _timeShoot;
    [SerializeField] private CheckTriggerEnemy isCheckDistance;
    [SerializeField] private Animator _aimRun;

    private bool isFlipRight;
    private float _maxTimeShoot;
    private Shooter _shooter;

    void Start()
    {
        _shooter = GetComponent<Shooter>();
        _maxTimeShoot = _timeShoot;
    }

    void Update()
    {
        float direction = _player.transform.position.x - transform.position.x;

        if (isCheckDistance.isCheckTrigger)
        {
            Vector3 pos = transform.position;
            pos.x += Mathf.Sign(direction) * _speedMove * Time.deltaTime;
            transform.position = pos;
            _aimRun.SetTrigger("isRunRobot");
        }

        if (isCheckDistance.isCheckTrigger)
        {
            _timeShoot -= Time.deltaTime;
            if (_timeShoot <= 0)
            {
                _shooter.Shoot(isCheckDistance.isCheckTrigger, direction);
                _timeShoot = _maxTimeShoot;
            }
        }

        if (direction < 0 && isFlipRight)
        {
            Flip();
        }

        else if (direction > 0 && !isFlipRight) 
        {
            Flip();
        }
    }

    public void Flip()
    {
        isFlipRight = !isFlipRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
