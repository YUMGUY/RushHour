using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // variables added by timmy
    public GameObject bar;
    public GameObject barChair;


    public Transform offscreen;
    public bool foundChair;
    public bool takenChair;
    public float findChairCooldown;

    public int chairPosition;

    private float moveTimer = 0;

    // hard code 5 seconds
    private float duration = 5f;
    // Start is called before the first frame update

    private float timeWaiting;

    private float irritationFactor;
    public MonsterDrink monsterDrink;
    private bool movingAway;
    private float timer;
    
    


    // Drink drink
    [SerializeField]
    public AnimationCurve curve;

    void Start()
    {

        //  bar = GameObject.Find("makeshift bar");
        bar = GameObject.FindGameObjectWithTag("TheBar");
        movingAway = false;



        timeWaiting = 0;
        foundChair = false;
        findSeat();

        findChairCooldown = 0;
        irritationFactor = 1;

        int spriteNumber = Random.Range(0, 50);
        if (spriteNumber <= 25) {
            this.GetComponent<SpriteRenderer>().sprite = GameHandler.possibleSprites[0];
        } else if (spriteNumber <= 35)
        {
            this.GetComponent<SpriteRenderer>().sprite = GameHandler.possibleSprites[1];
        }
        else if(spriteNumber <= 45)
        {
            this.GetComponent<SpriteRenderer>().sprite = GameHandler.possibleSprites[2];
        } else
        {
            this.GetComponent<SpriteRenderer>().sprite = GameHandler.possibleSprites[3];
        }

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

        if(!foundChair)
        {
            findSeat();
        }
        
        if(foundChair == true)
        {
            moveTimer += Time.deltaTime;
            // add a timer for how long the guy gonna stay there
            this.transform.position = Vector2.Lerp(transform.position, barChair.transform.position, moveTimer / duration);
        }

        if(movingAway)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, offscreen.transform.position, timer / duration);
            
            if(timer/duration >= .90)
            {
                Destroy(this.gameObject);
            }
        }
    }
    
    // find available seat at the bar
    public void findSeat()
    {
        // find nearest available chair
            for (int i = 0; i < bar.transform.GetComponentsInChildren<seatProperties>().Length; i++)
            {
                if (bar.transform.GetChild(i).GetComponent<seatProperties>().seatOpen == true && bar.transform.GetChild(i).gameObject.activeInHierarchy == true)
                {
                    // close the seat
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
    }
    public void moveOffScreen()
    {
        movingAway = true;
        timer = 0;
        
    }

    public float getIrritationFactor()
    {
        return irritationFactor;
    }

    public void setIrritationFactor(float factor)
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

    // find available seat at the bar
  

}
