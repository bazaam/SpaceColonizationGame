using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public void SetPlayerColor(Color color)
    {
        FindObjectOfType<LocalSetupData>().MyPlayerColor = color;
        Debug.Log("Color received = " + color);
        Debug.Log("New player color is: " + FindObjectOfType<LocalSetupData>().MyPlayerColor);
    }

    public void JoinNetworkLobby()
    {
        SceneManager.LoadScene(1);
    }
}
