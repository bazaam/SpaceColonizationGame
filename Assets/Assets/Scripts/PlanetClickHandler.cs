using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClickHandler : MonoBehaviour
{
    private int owner = 0;
    private int planetType = 0;
    private bool isActive = false;

    private void OnMouseOver()
    {
        //highlight planet

        if (Input.GetMouseButtonDown(1))
        {
            //display planet properties
        }
    }

}