using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private MonsterQueue queue;
    private float totalGameTime;
    private float totalSuccessfulDrinks;
    private float awareness;
    private const float mediumIncrease = 3;
    private const float hardIncrease = 6;

    // Music Assets
    public AudioSource easyMusic;
    public AudioSource hardMusic;
    public AudioSource talking;
    public AudioSource happyGrunt;
    public AudioSource slide;

    // UI control
    public Image awarenessBar;

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


    void Start()
    {
        totalGameTime = 0;
        awareness = 0;
        easyMusic.Play();
        possibleSprites = new List<Sprite>();

        awarenessBar.fillAmount = 0;


        // create first attendent and put them in queue
        Monster monster = createMonster();
        box1.updateBubble(monster.getMonsterDrink());
        queue = GetComponent<MonsterQueue>();
        queue.insert(monster);

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

        // do updates in difficulty based on time
        if (gameMode == 0 && totalSuccessfulDrinks >= 5)
        {
            gameMode = 1;
            Monster monster = createMonster();
            queue.insert(monster);
            box2.gameObject.SetActive(true);
            box2.updateBubble(monster.getMonsterDrink());

        } else if(gameMode == 1 && totalSuccessfulDrinks >= 10)
        {
            
            gameMode = 2;
            easyMusic.Stop();
            hardMusic.Play();
            Monster monster = createMonster();

            box3.gameObject.SetActive(true);
            box3.updateBubble(monster.getMonsterDrink());
            queue.insert(monster);

        }

        // Do time based decreases to awareness
        float deltaTime = Time.deltaTime;
        for(int i = 0; i < queue.getSize(); i++)
        {
            if ((int)queue.getTimeWaiting(i) < (int)(queue.getTimeWaiting(i) + deltaTime))
            {
                awareness += ((queue.getTimeWaiting(i) / 5) * queue.getIrritationFactor(i) * .5f);
            } 
        }
        queue.increaseAllTimeWaiting(Time.deltaTime);
        

        // trigger mini game if awareness is over 100
        if (awareness >= 100)
        {
            triggerMiniGame();
        }

        // update awareness UI
        awarenessBar.fillAmount = awareness / 100;
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
            queue.remove(index);
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
            queue.insert(monster);
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
            monster.setIrritationFactor(2);
        }

        if (gameMode == 2)
        {
            monster.setIrritationFactor(3);
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
}
