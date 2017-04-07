using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlanetData : NetworkBehaviour
{
    public GameObject planetOwnershipOverlay;
    public string planetType;
    public int startingUnits;
    public int basePopulationCap;

    public float manualResourceInitializationPrototypeOnly;

    //planet resource values
    public float Iron { get; private set; }
    public float Carbon { get; private set; }
    public float Farm { get; private set; }
    public float City { get; private set; }

    //planet stat values
    public float GrowthRate { get; private set; }
    private int populationCap;
    private PlanetUnitHandler myUnits;



    private int numberOfUnits = 0;
    private GameObject owner;

    // PlanetTypeRegistry planetTypeRegistry;

    private void Awake()
    {
        NetworkServer.Spawn(this.gameObject);
    }

    void Start()
    {
        myUnits = this.GetComponent<PlanetUnitHandler>();
        //junk resource value initializer -- TEMPORARY REPLACE THIS
        populationCap = basePopulationCap;
        GrowthRate = 1;
        if (planetType != null)
        {
            if (planetType == "Iron")
            {
                Iron = manualResourceInitializationPrototypeOnly;
            }
            if (planetType == "Carbon")
            {
                Carbon = manualResourceInitializationPrototypeOnly;
            }
            if (planetType == "Farm")
            {
                Farm = manualResourceInitializationPrototypeOnly;
            }

            if (planetType == "City")
            {
                City = manualResourceInitializationPrototypeOnly;
            }
        }
        // planetTypeRegistry = FindObjectOfType<PlanetTypeRegistry>();
        numberOfUnits = startingUnits;
        // gameObject.GetComponent<SpriteRenderer>().color = planetTypeRegistry.GetPlanetTypeColor(planetType);
	}
	
	void Update()
    {
		
	}

    public void ReleaseUnits(int quantity)
    {
        numberOfUnits -= quantity;
        //Debug.Log(this.name + " lost " + quantity + " units, and now has " + numberOfUnits + " units.");
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
        if (owner == null)
        {
            myUnits.InitiatePlanetPopulationControl();
        }
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
        return populationCap;
    }

    public void UpdatePlanetStats()
    {
        populationCap = (int)Mathf.Round(basePopulationCap * (1 + owner.GetComponent<PlayerData>().PopulationCapModifier));
        GrowthRate = 1 - owner.GetComponent<PlayerData>().PopulationGrowthRateModifier;
    }
}
