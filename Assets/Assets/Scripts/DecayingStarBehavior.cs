using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayingStarBehavior : MonoBehaviour
{
    private List<GameObject> unitBundlesInArea = new List<GameObject>();
    private bool unitEnteringThisFrame = false;
    private List<GameObject> flaggedForRemoval = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "travellingUnit")
        {
            unitEnteringThisFrame = true;
            if (unitBundlesInArea.Count == 0)
            {
                StartCoroutine(DestroyPlayerUnits());
            }
            unitBundlesInArea.Add(collider.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        unitBundlesInArea.Remove(collider.gameObject);
        if (unitBundlesInArea.Count ==0)
        {
            if (!unitEnteringThisFrame)
            {
                StopCoroutine(DestroyPlayerUnits());
            }
            unitEnteringThisFrame = false;
        }
    }

    private IEnumerator DestroyPlayerUnits()
    {
        for (;;)
        {
            if (unitBundlesInArea.Count > 0)
            {
                foreach (GameObject unitBundle in unitBundlesInArea)
                {
                    if (unitBundle)
                    {
                        TravellingUnit units = unitBundle.GetComponent<TravellingUnit>();
                        if (units.NumberOfUnits > 0)
                        {
                            units.DestroyUnits(1);
                        }
                        else if (units.NumberOfUnits <= 0)
                        {
                            flaggedForRemoval.Add(unitBundle);
                        }
                    }
                }
                foreach (GameObject objectToRemove in flaggedForRemoval)
                {
                    unitBundlesInArea.Remove(objectToRemove);
                    Destroy(objectToRemove);
                }
                flaggedForRemoval.RemoveAll(delegate (GameObject o) { return o == null; });
                yield return new WaitForSeconds(0.8f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
