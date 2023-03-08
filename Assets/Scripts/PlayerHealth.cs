using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : ObjectHealth
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    public override void HandleCollision(GameObject otherObject)
    {
        if(otherObject.CompareTag("Zombie"))
        {
            Zombie zombie = otherObject.GetComponent<Zombie>();
            SubtractHealth(zombie.damage);
        }

        base.HandleCollision(otherObject);
    }

    public override void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        base.OnDeath();
    }
}
