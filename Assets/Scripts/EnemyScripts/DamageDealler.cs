using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damaheable"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
