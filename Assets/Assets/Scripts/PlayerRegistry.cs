using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRegistry : MonoBehaviour {
    Dictionary<int, Color32> PlayerColors;

	void Awake()
    {
        PlayerColors = new Dictionary<int, Color32>();
        PlayerColors.Add(0, new Color32(97, 97, 97, 255));
        PlayerColors.Add(1, new Color32(199, 9, 13, 255));
        PlayerColors.Add(2, new Color32(27, 28, 244, 255));
    }

    public Color32 GetPlayerColor(int player)
    {
        return PlayerColors[player];
    }
	
}
