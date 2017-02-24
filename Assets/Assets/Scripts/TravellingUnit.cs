using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingUnit : MonoBehaviour
{

    private int units;
    private GameObject owner;
    private float speed = 0;
    private UnitBundle unitBundle;
    private GameObject target;
    private GameObject spriteObject;

    TravellingUnitsHandler UnitsHandler;


    private void Awake()
    {
        UnitsHandler = FindObjectOfType<TravellingUnitsHandler>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, target.transform.position.y), speed * Time.deltaTime);
    }

    public void Initialize(int newUnits, GameObject newOwner, GameObject newTarget, float newSpeed)
    {
        units = newUnits;
        owner = newOwner;
        target = newTarget;
        speed = newSpeed;
        gameObject.SetActive(true);
        unitBundle = new UnitBundle(units, owner, this.gameObject);
        UnitsHandler.RegisterUnitBundle(unitBundle);
      
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            target.GetComponent<PlanetData>().AddUnits(units, owner);
            Destroy(gameObject);
        }
    }

}
