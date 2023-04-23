using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)){
            Damage(10);
        }
        if (Input.GetKeyDown(KeyCode.H)){
            Heal(10);
        }

    }

    public void SetHealth(int maxHealth, int health){
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    public void Damage(int amount){
        this.health -= amount;
        negativeCheck(amount);
        this.health -= amount;
        if (health <= 0){
            Die();
        }
    }


    public void Heal(int amount){
        negativeCheck(amount);

        bool isOverMaxHP = health + amount > MAX_HEALTH;

        if (isOverMaxHP){
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }

        
        }


    public void negativeCheck(int amount){
        if (amount < 0)
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing");
    }


    private void Die(){
        Debug.Log("For: " + gameObject.name + " Digital death comes...");
        Destroy(gameObject);
    }

}


