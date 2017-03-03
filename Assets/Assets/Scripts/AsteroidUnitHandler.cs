using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidUnitHandler : MonoBehaviour
{
    public GameObject travellingUnitsPrefab;
    AsteroidData data;

    private void Start()
    {
        data = this.GetComponent<AsteroidData>();
    }

    public void SendUnits(GameObject targetPlanet, GameObject planetOwner)
    {
        int unitsToRelease = (data.GetNumberOfUnits() / 2);
        data.ReleaseUnits(unitsToRelease);
        TravellingUnit units = Instantiate(travellingUnitsPrefab, this.gameObject.transform.position, Quaternion.identity).GetComponent<TravellingUnit>();
        units.Initialize(unitsToRelease, data.GetOwner(), targetPlanet, 10.0f * (1 + planetOwner.GetComponent<PlayerData>().UnitSpeedModifier));
    }
    
    private void UpdatePopulation()
    {
        if (data.GetNumberOfUnits() > data.GetPopulationCap())
            data.ReleaseUnits(1);
    }

    private IEnumerator DecayPopulation()
    {
        for (;;)
        {
            if (data.GetNumberOfUnits() > data.GetPopulationCap())
                UpdatePopulation();
            yield return new WaitForSeconds(0.5f);
        }
    }
}