using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalClickHandler : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(playerCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
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

        if (Input.GetMouseButtonUp(0))
        {
            if (isPlanetActive)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider)
                {
                    GameObject releaseObject = hit.transform.gameObject;
                    if (releaseObject.tag == "planet")
                    {
                        PlanetData planet = releaseObject.GetComponent<PlanetData>();
                        if (releaseObject != activePlanet)
                        {
                            PlanetUnitHandler planetUnits = activePlanet.GetComponent<PlanetUnitHandler>();
                            planetUnits.SendUnits(releaseObject);
                        }
                    }

                }
            }
            isPlanetActive = false;
        }
    }
}
