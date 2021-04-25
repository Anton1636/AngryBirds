using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private string remoteLauer = "RemotePlayer";
    private Camera scaneCamera;

    [SerializeField]
    Behaviour[] componentsToDisable;

    private void Start()
    {
        if(!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
            gameObject.layer = LayerMask.NameToLayer(remoteLauer);
        }
        else
        {
            scaneCamera = Camera.main;

            if(scaneCamera != null)
            {
                scaneCamera.gameObject.SetActive(false);
            }
        }
        transform.name = "Player" + GetComponent<NetworkIdentity>().netId;
    }

    private void OnDisable()
    {
        if (scaneCamera != null)
        {
            scaneCamera.gameObject.SetActive(true);
        }
    }
}
