using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // variables added by timmy
    public GameObject bar;
    private GameObject barChair;


    public GameObject offscreen;
    public bool foundChair;
    public bool takenChair;
    public float findChairCooldown;

    public int chairPosition;

    private float moveTimer = 0;
    private float duration = 3f;
    // Start is called before the first frame update

    private float timeWaiting;
    private int irritationFactor;
    private MonsterDrink monsterDrink;

    void Start()
    {

        bar = GameObject.Find("makeshift bar");




        timeWaiting = 0;
        // drink = Drink();
        // drink.randomizeKeys();

        findChairCooldown = 0;
        irritationFactor = 1;

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
                    // close the seat
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

    public void moveOffScreen()
    {
        transform.position = Vector3.Lerp(transform.position, offscreen.transform.position, moveTimer/duration);
    }

    public int getIrritationFactor()
    {
        return irritationFactor;
    }

    public void setIrritationFactor(int factor)
    {
        irritationFactor = factor;
    }

    public void setMonsterDrink(MonsterDrink md)
    {
        monsterDrink = md;
    }

    public MonsterDrink getMonsterDrink()
    {
        return monsterDrink;
    }
}
