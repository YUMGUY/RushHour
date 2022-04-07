using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassOnBar : MonoBehaviour
{
    public GameObject currDrink;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < 10; i++) {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = currDrink.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
        }
        transform.GetChild(8).GetChild(0).GetComponent<SpriteRenderer>().sprite = currDrink.transform.GetChild(8).GetChild(0).GetComponent<SpriteRenderer>().sprite;


    }
}
