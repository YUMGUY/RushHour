using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassOnBar : MonoBehaviour
{
    public GameObject currDrink;

    private Sprite backOfFingerSpr;
    private GameObject skewerObj;

    // Start is called before the first frame update
    void Start()
    {
        //backOfFingerSpr = transform.GetChild(8).GetChild(0).GetComponent<SpriteRenderer>().sprite;
        skewerObj = transform.GetChild(11).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < 10; i++) {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = currDrink.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
        }
        transform.GetChild(8).GetChild(0).GetComponent<SpriteRenderer>().sprite = currDrink.transform.GetChild(8).GetChild(0).GetComponent<SpriteRenderer>().sprite;
        //backOfFingerSpr = currDrink.transform.GetChild(8).GetChild(0).GetComponent<SpriteRenderer>().sprite;

        if (currDrink.transform.GetChild(11).gameObject.activeSelf)
        {
            //transform.transform.GetChild(11).gameObject.SetActive(true);
            skewerObj.SetActive(true);
        }
        else {
            //transform.transform.GetChild(11).gameObject.SetActive(false);
            skewerObj.SetActive(false);
        }

    }
}
