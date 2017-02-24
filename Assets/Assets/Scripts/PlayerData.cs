using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Color32 playerColor;
    public int playerID;
    private GameObject startingPlanet;

    void Start()
    {
    }

    void Update()
    {

    }

    public void InitializePlayerData(Color32 color, int ID, GameObject planet)
    {
        playerColor = color;
        playerID = ID;
        startingPlanet = planet;
        PlayerRegistry.instance.RegisterPlayer(playerID, playerColor, startingPlanet);

    }
}
