using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    public GameObject planetOwnershipOverlay;
    public int owner = 0;
    public int startingUnits;

    private int type = 0;
    private int numberOfUnits = 0;

    PlayerRegistry players;

	// Use this for initialization
	void Start()
    {
        players = FindObjectOfType<PlayerRegistry>();
        UpdateOwner(owner);
        numberOfUnits = startingUnits;
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public void ReleaseUnits(int quantity)
    {
        numberOfUnits -= quantity;
        Debug.Log(this.name + " lost " + quantity + " units, and now has " + numberOfUnits + " units.");
    }

    public void AddUnits(int quantity, int unitsOwner)
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

    public int GetOwner()
    {
        return owner;
    }

    public void UpdateOwner(int newOwner)
    {
        if (newOwner != owner)
            owner = newOwner;
        planetOwnershipOverlay.GetComponent<SpriteRenderer>().color = players.GetPlayerColor(newOwner);

    }
}
