using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClickHandler : MonoBehaviour
{
    private int owner = 0;
    private int planetType = 0;
    private bool isActive = false;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}



    private void OnMouseOver()
    {
        //highlight planet

        if (Input.GetMouseButtonDown(1))
        {
            //display planet properties
        }
    }

    private void OnMouseUp()
    {
        
    }
}
