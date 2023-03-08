using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : ObjectHealth
{
    public GameObject remains;
    public GameObject explosion;

    public override void HandleCollision(GameObject otherObject)
    {
        if(otherObject.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Bullet bullet = otherObject.GetComponent<Bullet>();
            SubtractHealth(bullet.damage);
        }

        base.HandleCollision(otherObject);
    }

    public override void OnDeath()
    {
        Instantiate(remains, transform.position, Quaternion.identity);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

        base.OnDeath();
    }
}
