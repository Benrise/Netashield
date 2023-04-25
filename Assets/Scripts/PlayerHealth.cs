using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealthe;
    [SerializeField] private float _currentHealthe;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private Animator _aimDead;
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayInput _enable;

    [SerializeField] private Transform _playerPosition;

    [SerializeField] private GameObject activeDeath;


    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource getDamageSound;
    private bool isAlive;

    private void Awake()
    {
        _currentHealthe = _maxHealthe;
        isAlive = true;
    }

    private void Update()
    {
        if (_currentHealthe >= 0)
            _hpText.text = _currentHealthe.ToString();

        if (!isAlive)
        {
            _aimDead.SetTrigger("Isdead");
            _player.layer = LayerMask.NameToLayer("Invize");
            _enable.enabled = false;
            Time.timeScale = 1;
            StartCoroutine(showDeathWindow());
        }

        if (_playerPosition.position.y <= -10)
        {
            _currentHealthe = 0;
            Time.timeScale = 1;
            StartCoroutine(showDeathWindow());
        }

    }

    IEnumerator showDeathWindow()
        {
            yield return new WaitForSeconds(3);
            deathSound.Play();
            activeDeath.SetActive(true);
        }
        public void TakeDamage(float damage)
        {
            getDamageSound.Play();
            _currentHealthe -= damage;
            CheckIsAlive();
        }

        private void CheckIsAlive()
        {
            if (_currentHealthe > 0)
            {
                isAlive = true;
            }

            else
            {
                isAlive = false;
                StartCoroutine(showDeathWindow());
            }
        }

    }