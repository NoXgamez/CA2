using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Roof : MonoBehaviour
{
    TilemapRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            spriteRenderer.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            spriteRenderer.enabled = true;
    }
}
