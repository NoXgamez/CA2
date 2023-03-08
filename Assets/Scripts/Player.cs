using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    float horizontal, vertical;
    Vector3 mouseWorldPosition;

    public Bullet bulletPrefab;
    public Transform bulletSpawnPoint;

    public int ammo = 20;
    public int maxAmmo = 20;
    public float regenerateAmmoTime = 2;
    public int ammoRegenAmount = 1;

    protected override void Start()
    {
        InvokeRepeating("RegenerateAmmo", regenerateAmmoTime, regenerateAmmoTime);

        base.Start();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        transform.up = mouseWorldPosition - transform.position;

        if(Input.GetButton("Fire2"))
        {
            SetState(CharacterState.Attack);
            if (Input.GetButtonDown("Fire1"))
            {
                if (ammo > 0)
                    Fire();
            }
        }
        else
        {
            SetState(CharacterState.Idle);
        }
    }

    private void FixedUpdate()
    {
        body.MovePosition(transform.position + new Vector3(horizontal, vertical, 0) * movementSpeed * Time.deltaTime);
    }

    void Fire()
    {
        Bullet inst = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        inst.SetDirection(transform.up);
        ammo--;
    }

    void RegenerateAmmo()
    {
        if (ammo < maxAmmo)
            ammo += ammoRegenAmount;

        if (ammo > maxAmmo)
            ammo = maxAmmo;
    }
}
