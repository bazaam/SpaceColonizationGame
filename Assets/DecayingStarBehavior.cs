using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayingStarBehavior : MonoBehaviour
{
    private List<GameObject> unitBundlesInArea = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "travellingUnit")
        {
            StartCoroutine(DestroyPlayerUnits(collision.gameObject));
        }
    }
    private void OnTriggerExit2D()
    {

    }

    private IEnumerator DestroyPlayerUnits(GameObject travellingUnitBundle)
    {
        TravellingUnit units = travellingUnitBundle.GetComponent<TravellingUnit>();
        for (;;)
        {
            if (travellingUnitBundle) 
            {
                if (units.NumberOfUnits > 0)
                {
                    units.DestroyUnits(1);
                    yield return new WaitForSeconds(0.5f);
                }
                else if (units.NumberOfUnits <= 0)
                {
                    Destroy(travellingUnitBundle);
                    yield break;
                }
            }
            else
            {
                yield break;
            }
        }
    }
}
