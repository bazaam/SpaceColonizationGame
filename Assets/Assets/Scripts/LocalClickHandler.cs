using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalClickHandler : NetworkBehaviour
{
    private bool isPlanetActive = false;
    private GameObject activePlanet;
    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(playerCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider)
                {
                    GameObject clickedObject = hit.transform.gameObject;
                    if (clickedObject.tag == "planet")
                    {
                        Debug.Log("Clicked on " + clickedObject.name);
                        PlanetData planet = clickedObject.GetComponent<PlanetData>();
                        if (planet.GetOwner() == this.gameObject)
                        {
                            isPlanetActive = true;
                            activePlanet = clickedObject;
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isPlanetActive)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(playerCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider)
                    {
                        GameObject releaseObject = hit.transform.gameObject;
                        if (releaseObject.tag == "planet")
                        {
                            PlanetData planet = releaseObject.GetComponent<PlanetData>();
                            if (releaseObject != activePlanet)
                            {
                                PlanetUnitHandler planetUnits = activePlanet.GetComponent<PlanetUnitHandler>();
                                planetUnits.SendUnits(releaseObject, gameObject);
                            }
                        }

                    }
                }
            }
            isPlanetActive = false;
        }
    }
}
