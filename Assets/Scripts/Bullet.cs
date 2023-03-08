using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed = 10;
    public int damage = 25;

    void Start()
    {
        //call CleanUp() after 2 seconds
        Invoke("CleanUp", 2);
    }

    public void SetDirection(Vector3 direction)
    {
        transform.up = direction.normalized;
        GetComponent<Rigidbody2D>().velocity = transform.up * movementSpeed;
    }

    void CleanUp()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Roof") && !collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
