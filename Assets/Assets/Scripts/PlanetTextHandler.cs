using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTextHandler : MonoBehaviour
{
    TextMesh planetText;
    PlanetData planet;
	// Use this for initialization
	void Start()
    {
        planetText = this.GetComponent<TextMesh>();
        planet = this.transform.parent.GetComponent<PlanetData>();
        this.GetComponent<Renderer>().sortingLayerID = this.transform.parent.GetComponent<Renderer>().sortingLayerID;
        this.GetComponent<Renderer>().sortingOrder = 10;
	}
	
	// Update is called once per frame
	void Update()
    {
        planetText.text = planet.GetNumberOfUnits().ToString();
	}
}
