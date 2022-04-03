using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public float lowerScreenBounds = -30f;
    public string PrimaryID = "Generic";
    public string SecondaryID = "Generic";

    public bool addedToDrink = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addToDrink() {
        addedToDrink = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(addedToDrink);
        /*
        if (transform.position.y <= lowerScreenBounds) { // Add || player is on outside bar screen, destroy immediately
            Destroy(gameObject);
        }
        */
    }

    private void OnBecameInvisible()
    {
        if (!addedToDrink) {
            Debug.Log("Left camera");
            Destroy(gameObject);
        }
        
    }
}
