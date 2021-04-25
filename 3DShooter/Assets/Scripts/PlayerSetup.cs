using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private string remoteLauer = "RemotePlayer";
    private Camera scaneCamera;

    [SerializeField]
    Behaviour[] componentsToDisable;

    private void Start()
    {
        if (!isLocalPlayer)
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

            if (scaneCamera != null)
            {
                scaneCamera.gameObject.SetActive(false);
            }
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();
        GameManager.RegisterPlayer(netID, player);
    }

    private void OnDisable()
    {
        if (scaneCamera != null)
        {
            scaneCamera.gameObject.SetActive(true);
        }
        GameManager.UnRegisterPlayer(transform.name);
    }
}
