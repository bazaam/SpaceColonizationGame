using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidData : MonoBehaviour
{
    public GameObject planetOwnershipOverlay;
    public string planetType;
    public int basePopulationCap;

    private int populationCap;
    private int numberOfUnits = 0;
    private GameObject owner;

    PlanetTypeRegistry planetTypeRegistry;

        void Start()
    {

    }
	
	void Update ()
    {
		
	}
    public void ReleaseUnits(int quantity)
    {
        numberOfUnits -= quantity;
        //Debug.Log(this.name + "lost" + quantity + "units, and now has" + numberOfUnits + "units,");
    }

    public void AddUnits(int quantity, GameObject unitsOwner)
    {
        if (unitsOwner == owner)
            numberOfUnits += quantity;
        else
        {
            if (quantity > numberOfUnits)
            {
                numberOfUnits = (quantity - numberOfUnits);
                UpdateOwner(unitsOwner);
            }
            else
                numberOfUnits -= quantity;
        }
    }

    public int GetNumberOfUnits()
    {
        return numberOfUnits;
    }

    public GameObject GetOwner()
    {
        return owner;
    }

    public void UpdateOwner(GameObject newOwner)
    {
        if (newOwner != owner)
        {
            PlayerData ownerData;

            if (owner != null)
            {
                ownerData = owner.GetComponent<PlayerData>();
                ownerData.UnregisterPlanet(gameObject);
                ownerData.UpdatePlayerStats();
                ownerData.UpdatePlanetStats();
            }
            owner = newOwner;
            ownerData = owner.GetComponent<PlayerData>();
            ownerData.RegisterPlanet(gameObject);
            ownerData.UpdatePlayerStats();
            ownerData.UpdatePlanetStats();
        }
        planetOwnershipOverlay.GetComponent<SpriteRenderer>().color = PlayerRegistry.instance.GetPlayerColor(newOwner.GetComponent<PlayerData>().PlayerID);
    }

    public int GetPopulationCap()
    {
        return basePopulationCap;
    }

    public void UpdatePlanetStats()
    {
        populationCap = (int)Mathf.Round(basePopulationCap * (1 + owner.GetComponent<PlayerData>().PopulationCapModifier));
    }
}
