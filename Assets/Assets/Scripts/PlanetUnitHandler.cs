using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlanetUnitHandler : NetworkBehaviour
{
    public GameObject travellingUnitsPrefab;
    PlanetData data;

    private void Start()
    {
        data = this.GetComponent<PlanetData>();
    }

    public void SendUnits(GameObject targetPlanet, GameObject planetOwner)
    {
        int unitsToRelease = (data.GetNumberOfUnits() / 2);
        data.ReleaseUnits(unitsToRelease);
        TravellingUnit units = Instantiate(travellingUnitsPrefab, this.gameObject.transform.position, Quaternion.identity).GetComponent<TravellingUnit>();
        units.Initialize(unitsToRelease, data.GetOwner(), targetPlanet, 20.0f * (1 + planetOwner.GetComponent<PlayerData>().UnitSpeedModifier));
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


    private IEnumerator GrowPopulation()
    {
        for (;;)
        {
            if (data.planetType == "Asteroid")
            {
                yield break;
            }
            if (data.GetNumberOfUnits() < data.GetPopulationCap())
            {
                UpdatePopulation();
            }
            yield return new WaitForSeconds(0.5f * data.GrowthRate);
        }
    }
    private IEnumerator DecayPopulation()
    {
        if (data.planetType == "Asteroid")
        {
            yield break;
        }
        for (;;)
        {
            if (data.GetNumberOfUnits() > data.GetPopulationCap())
                UpdatePopulation();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void InitiatePlanetPopulationControl()
    {
        StartCoroutine(GrowPopulation());
        StartCoroutine(DecayPopulation());
    }

}
