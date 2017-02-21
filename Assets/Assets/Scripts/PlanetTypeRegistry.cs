using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTypeRegistry : MonoBehaviour {
    Dictionary<string, Color32> PlanetTypeColors;

	    void Awake()
    {
        PlanetTypeColors = new Dictionary<string, Color32> <string, Color32 > ();
        PlanetTypeColors.Add(Normal, new Color32(97, 97, 97, 255));
        PlanetTypeColors.Add(Iron, new Color32(223, 135, 62, 147));
        PlanetTypeColors.Add(Carbon, new Color32(73, 191, 108, 255));
        PlanetTypeColors.Add(Farm, new Color32(192, 137, 225, 255));
        PlanetTypeColors.Add(City, new Color32(214, 203, 27, 255));
	}
	
	public Color32 GetPlanetTypeColor(string planettype)
	{
        return PlanetTypeColors[planettype];	
	}
}
