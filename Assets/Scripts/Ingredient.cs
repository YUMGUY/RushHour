using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public float lowerScreenBounds = -10f;
    public string PrimaryID = "Generic";
    public string SecondaryID = "Generic";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= lowerScreenBounds) { // Add || player is on outside bar screen, destroy immediately
            Destroy(gameObject);
        }

    }
}
