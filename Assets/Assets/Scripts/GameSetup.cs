using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public List<PlayerInitializer> players;
    

    private void Start()
    {
        InitializePlayers();
    }

    private void InitializePlayers()
    {
        foreach (PlayerInitializer player in players)
        {
            GameObject newPlayer = Instantiate(player.playerPrefab, new Vector3(-178, -37, -10), Quaternion.identity);
            newPlayer.GetComponent<PlayerData>().InitializePlayerData(player.color, player.id, player.startPlanet);
            player.startPlanet.GetComponent<PlanetData>().UpdateOwner(newPlayer);
        }
    }

}
[System.Serializable]
public class PlayerInitializer
{
    public GameObject startPlanet;
    public int id;
    public Color32 color;
    public GameObject playerPrefab;
}
