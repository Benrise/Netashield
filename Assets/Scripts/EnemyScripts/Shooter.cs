using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private Transform _firePoint;

    public void Shoot(bool direction, float direct)
    {
        GameObject currentBullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if (direction && direct > 0)
        {
            currentBulletVelocity.velocity = new Vector2(_fireSpeed * 1, currentBulletVelocity.velocity.y);
        }

        else if (direction && direct < 0)
        {
            currentBulletVelocity.velocity = new Vector2(_fireSpeed * -1, currentBulletVelocity.velocity.y);
        }
    }
}
