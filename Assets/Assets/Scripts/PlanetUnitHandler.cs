using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUnitHandler : MonoBehaviour
{
    public GameObject travellingUnitsPrefab;
    PlanetData data;

    private void Start()
    {
        data = this.GetComponent<PlanetData>();
        StartCoroutine(MaintainPopulation());
    }

    public void SendUnits(GameObject targetPlanet)
    {
        int unitsToRelease = (data.GetNumberOfUnits() / 2);
        data.ReleaseUnits(unitsToRelease);
        TravellingUnit units = Instantiate(travellingUnitsPrefab, this.gameObject.transform.position, Quaternion.identity).GetComponent<TravellingUnit>();
        units.Initialize(unitsToRelease, data.GetOwner(), targetPlanet, 10.0f);
    }

    private void UpdatePopulation()
    {
        if (data.GetNumberOfUnits() < data.GetPopulationCap())
            data.AddUnits(1, data.GetOwner());
        else if (data.GetNumberOfUnits() > data.GetPopulationCap())
            data.ReleaseUnits(1);
    }
    private void CheckForPopulationDecay()
    {
        if (data.GetNumberOfUnits() < data.GetPopulationCap())
            data.AddUnits(1, data.GetOwner());
    }


    private IEnumerator MaintainPopulation()
    {

        for (;;)
        {
            UpdatePopulation();
            yield return new WaitForSeconds(.8f);
        }
    }
}
