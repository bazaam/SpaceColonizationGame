using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUnitHandler : MonoBehaviour
{
    public GameObject travellingUnitsPrefab;


    public void SendUnits(GameObject targetPlanet)
    {
        PlanetData data = this.GetComponent<PlanetData>();
        int unitsToRelease = (data.GetNumberOfUnits() / 2);
        data.ReleaseUnits(unitsToRelease);
        TravellingUnit units = Instantiate(travellingUnitsPrefab, this.gameObject.transform.position, Quaternion.identity).GetComponent<TravellingUnit>();
        units.Initialize(unitsToRelease, data.GetOwner(), targetPlanet, 10.0f);
    }
}
