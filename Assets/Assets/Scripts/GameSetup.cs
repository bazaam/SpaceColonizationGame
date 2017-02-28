using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameSetup
{
    public static GameSetup instance = new GameSetup();


    public void RegisterPlayer(GameObject player)
    {
        JunkDataStorage data = GameObject.FindObjectOfType<JunkDataStorage>();
        GameObject newPlayerStartingPlanet = data.startingPlanets[0];
        player.GetComponent<PlayerData>().InitializePlayerData(data.playerColors[0], data.playerIDs[0], newPlayerStartingPlanet);
        newPlayerStartingPlanet.GetComponent<PlanetData>().UpdateOwner(player);

        data.startingPlanets.RemoveAt(0);
        data.playerColors.RemoveAt(0);
        data.playerIDs.RemoveAt(0);

        //GameObject newPlayer = Instantiate(player.playerPrefab, new Vector3(-178, -37, -10), Quaternion.identity);
        //newPlayer.GetComponent<PlayerData>().InitializePlayerData(player.color, player.id, player.startPlanet);
        //player.startPlanet.GetComponent<PlanetData>().UpdateOwner(newPlayer);
    }

}
