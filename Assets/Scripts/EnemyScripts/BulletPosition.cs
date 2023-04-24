using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPosition : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private SpriteRenderer sp;

    private void Update()
    {
        if (_firePoint.localScale.x > 0 && sp.flipX)
        {
            sp.flipX = !sp.flipX;
        }
        else if (_firePoint.localScale.x < 0 && !sp.flipX)
        {
            sp.flipX = !sp.flipX;
        }
    }

}
