using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    public GameObject planetOwnershipOverlay;
    public string planetType;
    public int startingUnits;
    public int populationCap;

    private int numberOfUnits = 0;
    private GameObject owner;
    private PlayerData ownerData;

    PlanetTypeRegistry planetTypeRegistry;

	void Start()
    {
        planetTypeRegistry = FindObjectOfType<PlanetTypeRegistry>();
        numberOfUnits = startingUnits;
        gameObject.GetComponent<SpriteRenderer>().color = planetTypeRegistry.GetPlanetTypeColor(planetType);
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
                owner = unitsOwner;
                numberOfUnits = (quantity - numberOfUnits);
                UpdateOwner(unitsOwner);
            }
            else
                numberOfUnits -= quantity;
        }
    }

    public int GetNumberOfUnits()
    {
        //Debug.Log(this.name + " has " + numberOfUnits + " units currently");
        return numberOfUnits;
    }

    public GameObject GetOwner()
    {
        return owner;
    }

    public void UpdateOwner(GameObject newOwner)
    {
        if (newOwner != owner)
            owner = newOwner;
        planetOwnershipOverlay.GetComponent<SpriteRenderer>().color = PlayerRegistry.instance.GetPlayerColor(newOwner.GetComponent<PlayerData>().playerID);
    }

    public int GetPopulationCap()
    {
        return populationCap;
    }
}
