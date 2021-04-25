using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class Player : NetworkBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    
    [SyncVar]
    private float currHealth;

    private void Awake()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;

        Debug.Log(transform.name + "health:" + currHealth);
    }
}
