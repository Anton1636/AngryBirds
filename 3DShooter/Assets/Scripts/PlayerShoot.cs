using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class PlayerShoot : NetworkBehaviour
{
    public Weapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No camera!");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,
                           cam.transform.forward,
                           out hit, weapon.range, mask))
        {
            if(hit.collider.tag == "Player")
            {
                cmdPlayerShoot(hit.collider.name, weapon.damage);
            }
        }
    }

    [Command]
    private void cmdPlayerShoot(string ID, float damage)
    {
        Debug.Log("In player" + ID + "shot");

        Player player = GameManager.GetPlayer(ID);
        player.TakeDamage(damage);
    }
}
