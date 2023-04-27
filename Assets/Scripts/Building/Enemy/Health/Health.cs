using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] private int health = 100;

    //Show HP
    public Slider sliderHP;

    private SpriteRenderer _playerImage;
    public Color damageColor = Color.red;

    public GameObject LoseWindow;

    private int MAX_HEALTH = 100;


    private RectTransform _rectTransform;

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.D)){
        //     Damage(10);
        // }
        // if (Input.GetKeyDown(KeyCode.H)){
        //     Heal(10);
        // }

    }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        if (gameObject.tag == "Enemy")
            return;
        sliderHP.value = 1.0f;
        _playerImage = GetComponent<SpriteRenderer>();
    }

    private void UpdateHealthBar()
    {
        if (gameObject.tag == "Enemy")
            return;
        float healthPercent = (float)health / (float)MAX_HEALTH;
        sliderHP.value = healthPercent;
    }


    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    public void Damage(int amount)
    {
        health -= amount;
        negativeCheck(amount);
        if (health <= 0)
        {
            UpdateHealthBar();
            if (gameObject.tag != "Enemy")
                StartCoroutine(ShowDamage());
            Die();
        }
        else if (gameObject.tag != "Enemy")
        {
            UpdateHealthBar();
            StartCoroutine(ShowDamage());
        }
    }

    IEnumerator ShowDamage()
    {
        _playerImage.color = damageColor; // устанавливаем цвет подсветки
        yield return new WaitForSeconds(0.1f); // ждем 0.1 секунды
        _playerImage.color = Color.white; // возвращаем исходный цвет
    }


    public void Heal(int amount)
    {
        negativeCheck(amount);

        bool isOverMaxHP = health + amount > MAX_HEALTH;

        if (isOverMaxHP)
        {
            health = MAX_HEALTH;
        }
        else
        {
            health += amount;
        }

        UpdateHealthBar();
    }


    public void negativeCheck(int amount)
    {
        if (amount < 0)
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing");
    }


    private void Die()
    {
        Debug.Log("For: " + gameObject.name + " Digital death comes...");
        Destroy(gameObject);
        StopAllCoroutines();
        if (gameObject.tag == "Enemy")
        {
            // FindObjectOfType<WaveSpawner>().enemiesKilledCount++;
            return;
        }
        Time.timeScale = 0;
        StopAllCoroutines();
        LoseWindow.SetActive(true);



    }

}


