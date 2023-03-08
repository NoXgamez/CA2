using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CharacterState
{
    Idle, Attack
}

public class Character : MonoBehaviour
{
    public CharacterState state;
    public Sprite idleSprite;
    public Sprite attackSprite;
    public float movementSpeed = 5;
    protected Rigidbody2D body;

    SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        SetState(CharacterState.Idle);
    }

    public void SetState(CharacterState newState)
    {
        state = newState;

        if (state == CharacterState.Idle)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else if (state == CharacterState.Attack)
        {
            spriteRenderer.sprite = attackSprite;
        }
    }
}
