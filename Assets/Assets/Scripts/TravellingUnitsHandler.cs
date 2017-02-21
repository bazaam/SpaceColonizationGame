using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingUnitsHandler : MonoBehaviour
{
    private List<UnitBundle> activeUnitBundles = new List<UnitBundle>();


    public void RegisterUnitBundle(UnitBundle newUnitBundle)
    {
        activeUnitBundles.Add(newUnitBundle);
    }
    public void UnregisterUnitBundle(UnitBundle bundleToRemove)
    {
        activeUnitBundles.Remove(bundleToRemove);
    }
}

public class UnitBundle
{
    private int numberOfUnits;
    private int owner;
    private GameObject attachedUnitsObject;

    public UnitBundle(int unitQuantity, int newOwner, GameObject newUnitsObject)
    {
        numberOfUnits = unitQuantity;
        owner = newOwner;
        attachedUnitsObject = newUnitsObject;
    }

    public void SetOwner(int newOwner)
    {
        owner = newOwner;
    }
    
    public void SetUnits(int unitQuantity)
    {
        numberOfUnits = unitQuantity;
    }

    public GameObject GetAttachedObject()
    {
        return attachedUnitsObject;
    }
}
