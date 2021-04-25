using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
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
        }
        else
        {
            scaneCamera = Camera.main;

            if(scaneCamera != null)
            {
                scaneCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if (scaneCamera != null)
        {
            scaneCamera.gameObject.SetActive(true);
        }
    }
}
