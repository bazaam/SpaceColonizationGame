using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRegistry
{
    public static PlayerRegistry instance = new PlayerRegistry();
    Dictionary<int, Color32> PlayerColors = new Dictionary<int, Color32>();


    public Color32 GetPlayerColor(int player)
    {
        return PlayerColors[player];
    }
	
    public void RegisterPlayer(int ID, Color32 color, GameObject startingPlanet)
    {
        PlayerColors.Add(ID, color);
    }
}
