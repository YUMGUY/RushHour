using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sceneref;
    public GameObject flag;

    private MonsterQueue queue;
    private float totalGameTime;
    private float totalSuccessfulDrinks;
    private float awareness;
    private float maxAwareness = 100;
    private const float mediumIncrease = 3;
    private const float hardIncrease = 7;

    // Music Assets
    public AudioSource easyMusic;
    public AudioSource hardMusic;
    public AudioSource talking;
    public AudioSource happyGrunt;
    public AudioSource slide;

    // int to keep track of game code
    // 0 = easy
    // 1 = medium
    // 2 = hard
    public int gameMode = 0;

    // keep track of awareness punishment
    private int punishment = 5;
    private int reward = 10;

    // TODO:
    public currDrink currentDrink;

    // PREFABS
    public GameObject monsterPrefab;

    // TODO: Initialize sprite list
    public static List<Sprite> possibleSprites;

    public GlassSlide glass;
    public Transform offTheBar;

    public DialogBox box1;
    public DialogBox box2;
    public DialogBox box3;

    public seatProperties stool1;
    public seatProperties stool2;
    public seatProperties stool3;


    void Start()
    {
        totalGameTime = 0;
        awareness = 0;
        easyMusic.Play();
        possibleSprites = new List<Sprite>();

        stool1.seatOpen = true;
        stool2.seatOpen = false;
        stool3.seatOpen = false;


        // create first attendent and put them in queue
        Monster monster = createMonster();
        box1.updateBubble(monster.getMonsterDrink());
        queue = GetComponent<MonsterQueue>();
        queue.insert(queue.getSize(), monster);

        // either in game manager or in Monster.cs, handle how monster will find a seat - Timmy ( rn i am doing code in Monster.cs for the finding the seat


        // currentDrink = Drink();
        // static Gameobject currentDrink; getcomponent to get the current drink's script
        box2.gameObject.SetActive(false);
        box3.gameObject.SetActive(false);

        fillSpriteList();
    }

    // Update is called once per frame
    void Update()
    {
        // check for key press
        if(Input.GetKeyDown(KeyCode.E))
        {
            compareDrink();
        }

        // add total game time
        totalGameTime += Time.deltaTime;

        // Do time based decreases to awareness
        float deltaTime = Time.deltaTime;
        for(int i = 0; i < queue.getSize(); i++)
        {
            if ((int)queue.getTimeWaiting(i) < (int)(queue.getTimeWaiting(i) + deltaTime))
            {
                awareness += ((queue.getTimeWaiting(i) / 5) * queue.getIrritationFactor(i) * .5f);
                flag.transform.position = new Vector2(flag.transform.position.x, flag.transform.position.y + 1 * Time.deltaTime * 1.5f);
            } 
        }
        queue.increaseAllTimeWaiting(Time.deltaTime);
        

        // trigger mini game if awareness is over 100
        if (awareness >= maxAwareness)
        {
            triggerMiniGame();
            sceneref.GetComponent<SceneControllerLite>().transitionToGame();
        }

        // update awareness UI
    }

    // TODO: boss mini game
    public void triggerMiniGame()
    {

    }

    public void compareDrink()
    {
        int index = -1;
        for(int i = 0; i < queue.getSize(); i++)
        {
            bool same = queue.getDrink(i).compareToCurrentDrink(currentDrink);
            if(same)
            {
                index = i;
                break;
            }
        }


        // if the drink was not found
        slide.Play();
        if(index == -1)
        {
            // animate off the bar
            glass.setDestination(offTheBar);
            awareness += punishment;
            punishment *= 2;

        } else
        {
            // slide to monster at position index
            Transform copy = queue.getMonsterTransform(index);
            glass.setDestination(copy);
            happyGrunt.Play();
            //queue.remove(index);
            awareness -= reward;
            punishment = 5;
            totalSuccessfulDrinks++;

            Monster monster = createMonster();
            if (index == 0)
            {
                box1.updateBubble(monster.getMonsterDrink());
            } else if(index == 1)
            {
                box2.updateBubble(monster.getMonsterDrink());
            } else
            {
                box3.updateBubble(monster.getMonsterDrink());
            }
            
            queue = GetComponent<MonsterQueue>();
            // queue.insert(index, monster);
            queue.replace(index, monster);
        }

        // do updates in difficulty based on drinks served
        if (gameMode == 0 && totalSuccessfulDrinks >= mediumIncrease)
        {
            gameMode = 1;
            Monster monster = createMonster();
            queue.insert(queue.getSize(), monster);
            stool2.seatOpen = true;
            box2.gameObject.SetActive(true);
            box2.updateBubble(monster.getMonsterDrink());

        }
        else if (gameMode == 1 && totalSuccessfulDrinks >= hardIncrease)
        {

            gameMode = 2;
            stool3.seatOpen = true;
            easyMusic.Stop();
            hardMusic.Play();
            Monster monster = createMonster();

            box3.gameObject.SetActive(true);
            box3.updateBubble(monster.getMonsterDrink());
            queue.insert(queue.getSize(), monster);

        }

        currentDrink.clearDrink();
    }

    public Monster createMonster()
    {
        // TODO: fix transform
        Debug.Log("Monster created");
        GameObject m = Instantiate(monsterPrefab, this.transform) as GameObject;
        Monster monster = m.GetComponent<Monster>();
        monster.offscreen = offTheBar;
        if (gameMode == 1)
        {
            monster.setIrritationFactor(1);
        }

        if (gameMode == 2)
        {
            monster.setIrritationFactor(2);
        }
        monster.setMonsterDrink(new MonsterDrink());
        return monster;
    }

    public void fillSpriteList()
    {
        SpriteRenderer[] childSprites = this.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spriteRenderer in childSprites)
        {
            possibleSprites.Add(spriteRenderer.sprite);
        }
    }

    public float getAwarenessRatio()
    {
        return awareness / maxAwareness;
    }
}
