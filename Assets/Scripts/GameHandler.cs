using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private MonsterQueue queue;
    private float totalGameTime;
    private float awareness;
    private const float mediumIncrease = 3;
    private const float hardIncrease = 6;

    // Music Assets
    public AudioSource easyMusic;
    public AudioSource hardMusic;

    // UI control
    public Image awarenessBar;

    // int to keep track of game code
    // 0 = easy
    // 1 = medium
    // 2 = hard
    private int gameMode = 0;

    // keep track of awareness punishment
    private int punishment = 5;
    private int reward = 10;

    // TODO:
    // public PlayerDrink currentDriks

    // PREFABS
    public GameObject monsterPrefab;

    void Start()
    {
        totalGameTime = 0;
        awareness = 0;
        easyMusic.Play();

        awarenessBar.fillAmount = 0;


        // create first attendent and put them in queue

        // make this actually be correct transform later
        GameObject m = Instantiate(monsterPrefab, this.transform) as GameObject;

        // CHANGE DONE BY TIMMY, test out 
        m.transform.position = new Vector2(5f, 0);
        Monster monster = m.GetComponent<Monster>();

        queue = GetComponent<MonsterQueue>();
        queue.insert(monster); 

        // either in game manager or in Monster.cs, handle how monster will find a seat - Timmy ( rn i am doing code in Monster.cs for the finding the seat


        // currentDrink = Drink();
        // static Gameobject currentDrink; getcomponent to get the current drink's script
        
    }

    // Update is called once per frame
    void Update()
    {
        // add total game time
        totalGameTime += Time.deltaTime;

        // do updates in difficulty based on time
        if(gameMode == 0 && totalGameTime >= mediumIncrease * 60)
        {
            gameMode = 1;
            Monster monster = createMonster();
            queue.insert(monster);
            // TODO: Increase queue size by one
        } else if(gameMode == 1 && totalGameTime >= hardIncrease * 60)
        {
            gameMode = 2;
            easyMusic.Stop();
            hardMusic.Play();
            Monster monster = createMonster();
            queue.insert(monster);
            // TODO: Increase queue size by one
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

    // compareDrink
    /*use a int to keep track of the monster it matches
     * public void compareDrink() {
     * 
     * int index = -1;
     * for(int i = 0; i < queue.getSize(); i++) {
     *      // compare using some equality method
     * }
     * if(i == -1) {
     *    drink slides off counter
     *    awareness += punishment;
     *      punishment*=2;
     * } else {
     *      slide to monster at position i
     *      
     *      queue.removeAt(i);
     *      
     *      // create a new monster
     *      Monster monster = createMonster();
            queue.insert(monster);
     *      
     *      awareness -= reward;
     *      punishment = 5;
     * }
     * 
     *  reset the current drink values
     * 
     * 
     * 
     * 
     * }
     */

    public Monster createMonster()
    {
        GameObject m = Instantiate(monsterPrefab, this.transform) as GameObject;
        Monster monster = m.GetComponent<Monster>();
        if (gameMode == 1)
        {
            monster.setIrritationFactor(2);
        }

        if (gameMode == 2)
        {
            monster.setIrritationFactor(3);
        }
        return monster;
    }
}
