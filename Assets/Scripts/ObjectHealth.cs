using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    public void AddHealth(int amount)
    {
        health += amount;
        if(health > maxHealth)
            health = maxHealth;
    }

    public void SubtractHealth(int amount)
    {
        health -= amount;
        if( health <= 0)
            OnDeath();
    }

    public virtual void OnDeath() { }

    public virtual void HandleCollision(GameObject otherObject) { }
}
