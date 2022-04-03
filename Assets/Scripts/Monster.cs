using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // variables added by timmy
    public GameObject bar;
    private GameObject barChair;
    public bool foundChair;
    public bool takenChair;
    public float findChairCooldown;

    public int chairPosition;

    private float moveTimer = 0;

    // hard code 5 seconds
    private float duration = 5f;
    // Start is called before the first frame update
    private float timeWaiting;
    // Drink drink
    [SerializeField]
    public AnimationCurve curve;
    void Start()
    {

        bar = GameObject.Find("makeshift bar");




        timeWaiting = 0;
        foundChair = false;
        // drink = Drink();
        // drink.randomizeKeys();

        findChairCooldown = 0;
    }

    public void increaseTimeWaiting(float additionalTime)
    {
        timeWaiting += additionalTime;
    }

    public float getTimeWaiting()
    {
        return timeWaiting;
    }

    private void Update()
    {
        if(foundChair == false)
        {
           for(int i = 0; i < bar.transform.childCount; ++i)
           {
                if(bar.transform.GetChild(i).GetComponent<seatProperties>().seatOpen == true && bar.transform.GetChild(i).gameObject.activeInHierarchy == true)
                {
                    barChair = bar.transform.GetChild(i).gameObject;

                    // so that the other monsters won't take the seat
                   
                    print("index is: " + i);

                    // for the queue - TIMMY
                    chairPosition = i;
                   
                    print(barChair.transform.position);
                   

                    barChair.GetComponent<seatProperties>().seatOpen = false;
                    foundChair = true;

                    // find nearest available chair
                    break;
                }
           }

            
           // if any chairs aren't found
        }

        if(foundChair == true)
        {
            print(this.gameObject.transform.position);
            moveTimer += Time.deltaTime;
            print(barChair.name);
            this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, barChair.transform.position, curve.Evaluate(moveTimer / duration));
        }

       
    }
    // find available seat at the bar
  
}
