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
    private float duration = 3f;
    // Start is called before the first frame update
    private float timeWaiting;
    // Drink drink

    void Start()
    {

        bar = GameObject.Find("makeshift bar");




        timeWaiting = 0;
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
        // process of finding chair
        if(foundChair == false)
        {
           for(int i = 0; i < bar.transform.childCount; ++i)
           {
                if(bar.transform.GetChild(i).GetComponent<seatProperties>().seatOpen == true)
                {
                    barChair = bar.transform.GetChild(i).gameObject;
                    print("index is: " + i);

                    // for the queue - TIMMY
                    chairPosition = i;
                    foundChair = true;
                    break;
                }
           }

           // if any chairs aren't found
        }

        moveTimer += Time.deltaTime;

        findMonsterSeat();
    }
    // find available seat at the bar
    public void findMonsterSeat()
    {
   
        
        if(foundChair == true && !takenChair)
        {
                transform.position = Vector3.Lerp(transform.position, barChair.transform.position, moveTimer/duration);

                if(Vector2.Distance(transform.position, barChair.transform.position) <= .2f)
                {

                        takenChair = true;
                }
        }
       
       
        
    }
}
