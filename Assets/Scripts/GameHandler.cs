using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sceneref;
    public GameObject flag;
    public GameObject cameraRef;
    private MoveCamera cameraScriptRef;
    public GameObject alertFlash;
    private bool hurryUpAlertSwitch = false;

    private MonsterQueue queue;
    private float totalGameTime;
    private float totalSuccessfulDrinks;
    private float awareness;
    private float maxAwareness = 100;
    private const float mediumIncrease = 5;
    private const float hardIncrease = 10;
    private const float maxIncrease = 15;
    public bool drinkPrimed = false;

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
    // 3 = max
    public int gameMode = 0;

    // keep track of awareness punishment
    private int punishment = 5;
    private int reward = 20;

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

    public GameObject shakingObject;
    public GameObject stirringObject;
    public GameObject juicingObject;
    public GameObject clearButton;

    public Transform seat1Slot;
    public Transform seat2Slot;
    public Transform seat3Slot;

    public Sprite awareEyeSpr;


    void Start()
    {
        

        totalGameTime = 0;
        awareness = 0;
        easyMusic.Play();
        possibleSprites = new List<Sprite>();

        stool1.seatOpen = true;
        stool2.seatOpen = false;
        stool3.seatOpen = false;

        cameraScriptRef = cameraRef.GetComponent<MoveCamera>();


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

        drinkPrimed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Holding Left Mouse Down");
            cameraScriptRef.canMove = false;
        }
        else if (Input.GetMouseButtonUp(0)) {
            cameraScriptRef.canMove = true;
        }


        // check for key press
        if (Input.GetKeyDown(KeyCode.E) && drinkPrimed && cameraScriptRef.originalscene)
        {
            drinkPrimed = false;
            StartCoroutine(compareDrink());
            //compareDrink();
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
                flag.transform.position = new Vector2(flag.transform.position.x, flag.transform.position.y + 1 * Time.deltaTime * 1.0f);
            } 
        }
        queue.increaseAllTimeWaiting(Time.deltaTime);


        if (awareness >= 75 && !hurryUpAlertSwitch) {
            hurryUpAlertSwitch = true;
            alertFlash.GetComponent<FlashAlert>().StartAlert("Hurry Up!", 0, 50, new Vector3(500, 35, 0), Color.red);
        }

        if (awareness < 75) {
            hurryUpAlertSwitch = false;
        }

        // trigger mini game if awareness is over 100 - Scratch that, just clear references to stuff and game over if awareness > 100
        if (awareness >= maxAwareness)
        {
            GameOver(); 
        }

        // update awareness UI
    }

    // TODO: boss mini game
    public void GameOver()
    {
        clearMinigameObjs();
        PlayerPrefs.SetInt("highScore", gameMode);
        sceneref.GetComponent<SceneControllerLite>().transitionToGame();
    }

    public void clearMinigameObjs() {
        shakingObject.SetActive(false);
        stirringObject.SetActive(false);
        juicingObject.SetActive(false);
        clearButton.SetActive(false);
    }
    

    IEnumerator compareDrink() {

        cameraScriptRef.canMove = false;
        
        int index = -1;
        for (int i = 0; i < queue.getSize(); i++)
        {
            bool same = queue.getDrink(i).compareToCurrentDrink(currentDrink);
            if (same)
            {
                index = i;
                break;
            }
        }


        // if the drink was not found
        slide.Play();
        if (index == -1)
        {
            // animate off the bar
            glass.setDestination(offTheBar);
            awareness += punishment;
            punishment *= 2;
            yield return new WaitForSeconds(1.0f);
            cameraRef.GetComponent<MoveCamera>().canMove = true;
        }
        else
        {
            // slide to monster at position index

            Transform copy = queue.getMonsterTransform(index);

            //Debug.Log("Served at index: "+index);

            if (index == 0)
            {
                glass.setDestination(seat1Slot);
            }
            else if (index == 1)
            {
                glass.setDestination(seat2Slot);
            }
            else if (index == 2)
            {
                glass.setDestination(seat3Slot);
            }
            else {
                Debug.Log("Index thing didn't work");
                glass.setDestination(copy);
            }

            yield return new WaitForSeconds(2);
            cameraRef.GetComponent<MoveCamera>().canMove = true;
            yield return new WaitForSeconds(1);
            happyGrunt.Play();
            //queue.remove(index);
            

            if (awareness - reward < 0)
            {
                awareness = 0;
            }
            else { 
                awareness -= reward;
            }

            //Debug.Log("Awareness: " + awareness);

            punishment = 5;
            totalSuccessfulDrinks++;

            Monster monster = createMonster();
            if (index == 0)
            {
                box1.updateBubble(monster.getMonsterDrink());
            }
            else if (index == 1)
            {
                box2.updateBubble(monster.getMonsterDrink());
            }
            else
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

            reward += 5;
            punishment += 1;

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

            reward += 3;
            punishment += 1;

        }
        else if (gameMode == 2 && totalSuccessfulDrinks >= maxIncrease)
        {
            //At max, no extra seats open. However, orders with 5 ingredients can be requested at this point
            gameMode = 3;

            reward += 5;
            punishment += 1;
        }


        yield return null;

        //currentDrink.clearDrink();

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
            monster.setIrritationFactor(1.5f);
        }
        if (gameMode >= 3)
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
