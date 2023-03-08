using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    public int damage = 10;
    public float minMovementSpeed = 1;
    public float maxMovementSpeed = 3;

    public float attackRange = 3;
    GameObject player;

    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);

        base.Start();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < attackRange)
        {
            SetState(CharacterState.Attack);

            transform.up = player.transform.position - transform.position;
        }
        else
        {
            SetState(CharacterState.Idle);
        }
    }

    private void FixedUpdate()
    {
        if(state == CharacterState.Attack)
        {
            body.MovePosition(transform.position + transform.up.normalized * movementSpeed * Time.deltaTime);
        }
    }
}
