using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTriggerEnemy : MonoBehaviour
{
    public bool isCheckTrigger = false;
    [SerializeField] private Animator _aimIdle;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isCheckTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCheckTrigger = false;
            _aimIdle.SetTrigger("isIdleRobot");
        }

    }
}
