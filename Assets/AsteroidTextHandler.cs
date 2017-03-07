using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTextHandler : MonoBehaviour
{
    TextMesh asteroidText;
    AsteroidData asteroid;
    // Use this for initialization
    void Start()
    {
        asteroidText = this.GetComponent<TextMesh>();
        asteroid = this.transform.parent.GetComponent<AsteroidData>();
        this.GetComponent<Renderer>().sortingLayerID = this.transform.parent.GetComponent<Renderer>().sortingLayerID;
        this.GetComponent<Renderer>().sortingOrder = 10;
    }

    // Update is called once per frame
    void Update()
    {
        asteroidText.text = asteroid.GetNumberOfUnits().ToString();
    }
}
