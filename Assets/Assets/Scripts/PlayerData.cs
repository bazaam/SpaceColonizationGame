using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Color32 playerColor;
    public int PlayerID { get; private set; }
    private GameObject startingPlanet;
    private List<GameObject> PlanetsOwned = new List<GameObject>();

    //player stats
    public float PopulationCapModifier { get; private set; }
    public float PopulationGrowthRateModifier { get; private set; }
    public float UnitSpeedModifier { get; private set; }
    public float UnitDefenseModifier { get; private set; }

    private void Awake()
    {
        GameSetup.instance.RegisterPlayer(gameObject);
    }

    public void InitializePlayerData(Color32 color, int ID, GameObject planet)
    {
        Debug.Log("Initializing player with color: " + color + " ID: " + ID + " coordinates: " + planet.transform.position);
        playerColor = color;
        PlayerID = ID;
        startingPlanet = planet;
        PlayerRegistry.instance.RegisterPlayer(PlayerID, playerColor, startingPlanet);
        transform.position = new Vector3(planet.transform.position.x, planet.transform.position.y, -10);
        
    }

    public void RegisterPlanet(GameObject planet)
    {
        PlanetsOwned.Add(planet);
    }
    public void UnregisterPlanet(GameObject planet)
    {
        PlanetsOwned.Remove(planet);
    }
    public void UpdatePlayerStats()
    {
        float newPopulationCap = 0;
        float newPopulationGrowth = 0;
        float newUnitSpeed = 0;
        float newDefense = 0;

        foreach (GameObject planet in PlanetsOwned)
        {
            newPopulationCap += planet.GetComponent<PlanetData>().Farm;
            newPopulationGrowth += planet.GetComponent<PlanetData>().City;
            newUnitSpeed += planet.GetComponent<PlanetData>().Carbon;
            newDefense += planet.GetComponent<PlanetData>().Iron;
        }
        PopulationCapModifier = newPopulationCap;
        PopulationGrowthRateModifier = newPopulationGrowth;
        UnitSpeedModifier = newUnitSpeed;
        UnitDefenseModifier = newDefense;

        //Debug.Log("New PopulationCapModifier = " + PopulationCapModifier + " , new PopulationGrowthRateModifier = " + PopulationGrowthRateModifier + " , new UnitSpeedModifier =  " + UnitSpeedModifier + " , new UnitDefenseModifier = " + UnitDefenseModifier);
    }
    public void UpdatePlanetStats()
    {
        foreach (GameObject planet in PlanetsOwned)
        {
            planet.GetComponent<PlanetData>().UpdatePlanetStats();
        }
    }

}
