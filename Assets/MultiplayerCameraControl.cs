using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiplayerCameraControl : NetworkBehaviour
{
    private void Start()
    {
        if (gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
            gameObject.GetComponent<Camera>().enabled = false;
    }
}
