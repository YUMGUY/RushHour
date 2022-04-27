using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDrink : MonoBehaviour

{
    // Start is called before the first frame update


    // THE MONSTER WILL HAVE A ARRAY OF SCRIPTABLE OBJECTS TO CHOOSE FROM
    public int Eyeballs1 = 0; //0 = no eyes, 1 = blue eyes, 2 = green eyes, 3 = brown eyes
    public int Eyeballs2 = 0;
    public int Eyeballs3 = 0;
    public int Gemstones = 0; //0 = no gems, 1 = pearls, 2 = diamonds, 3 = heart gems
    public int Fruits = 0; //0 = no fruit, 1 = firefruit, 2 = icefruit, 3 = elecfruit
    public bool Fingers = false; //false = no finger
    public bool Hearts = false; //false = no hearts
    public bool Tentacles = false; //flase = no tentacles
    public int LiquidBase = 0; //0 = empty glass, 1 = lava slime, 2 = blood, 3 = brainjuice, 4 = tonic water

    public bool hasBeenStirred = false;
    public bool hasBeenShaken = false;
    public bool hasBeenJuiced = false;

    public int size = 0;

    public MonsterDrink()
    {

        GameHandler gameHandlerRef = FindObjectOfType<GameHandler>();
        int currDifficultyLvl = gameHandlerRef.gameMode;

        // everything needs a liquor
        LiquidBase = Random.Range(1, 5);
        size++;

        int orderSize = size;

        if (currDifficultyLvl == 0)
        {
            orderSize = Random.Range(1, 2);
            //Debug.Log("Should be on level 0");
        }
        else if (currDifficultyLvl == 1)
        {
            orderSize = Random.Range(1, 3);
            //Debug.Log("Should be on level 1");
        }
        else if (currDifficultyLvl == 2)
        {
            orderSize = Random.Range(2, 4);
            //Debug.Log("Should be on level 2");
        }
        else
        {
            orderSize = Random.Range(3, 5);
            //Debug.Log("Should be on level 3");
        }


        while (size != orderSize)
        {
            int randomSelection = Random.Range(0, 6);

            if(randomSelection == 0)
            {
                if(Eyeballs1 == 0)
                {
                    Eyeballs1 = Random.Range(1, 4);
                    size++;
                } else if(Eyeballs2 == 0)
                {
                    Eyeballs2 = Random.Range(1, 4);
                    size++;
                } else
                {
                    Eyeballs3 = Random.Range(0, 4);
                    size++;
                }
            }

            else if(randomSelection == 1 && Gemstones == 0)
            {
                Gemstones = Random.Range(1, 4);
                size++;
            }

            else if (randomSelection == 2 && Fruits == 0)
            {
                Fruits = Random.Range(1, 4);
                size++;
            }

            else if (randomSelection == 3 && !Fingers)
            {
                Fingers = true;
                size++;
            }

            else if (randomSelection == 4 && !Hearts)
            {
                Hearts = true;
                size++;
            }

            else if (randomSelection == 4 && !Tentacles)
            {
                Tentacles = true;
                size++;
            }
        }

        int mixingMethod = Random.Range(0, 3);
        switch(mixingMethod)
        {
            case 0:
                this.hasBeenStirred = true;
                size++;
                break;
            case 1:
                this.hasBeenShaken = true;
                size++;
                break;
            case 2:
                this.hasBeenJuiced = true;
                size++;
                break;
        }
    }

    // want eyes to not conform to any order
    private bool compareEyes(currDrink drink)
    {
        bool eyes = true;

        // one or no eyes
        if (Eyeballs1 == 0 || Eyeballs2 == 0)
        {
            eyes = eyes && (drink.Eyeballs1 == this.Eyeballs1);
            eyes = eyes && (drink.Eyeballs2 == this.Eyeballs2);
            eyes = eyes && (drink.Eyeballs3 == this.Eyeballs3);
        }

        // two eyes
        else if (Eyeballs2 != 0 && Eyeballs3 == 0)
        {
            bool order1 = (drink.Eyeballs1 == this.Eyeballs1) && (drink.Eyeballs2 == this.Eyeballs2);
            bool order2 = (drink.Eyeballs1 == this.Eyeballs2) && (drink.Eyeballs2 == this.Eyeballs1);
            eyes = (order1 || order2) && (drink.Eyeballs3 == this.Eyeballs3);
        }

        // three eyes
        else
        {
            bool order1 = (drink.Eyeballs1 == this.Eyeballs1) && (drink.Eyeballs2 == this.Eyeballs2) && (drink.Eyeballs3 == this.Eyeballs3);
            bool order2 = (drink.Eyeballs1 == this.Eyeballs1) && (drink.Eyeballs2 == this.Eyeballs3) && (drink.Eyeballs3 == this.Eyeballs2);
            bool order3 = (drink.Eyeballs1 == this.Eyeballs2) && (drink.Eyeballs2 == this.Eyeballs1) && (drink.Eyeballs3 == this.Eyeballs3);
            bool order4 = (drink.Eyeballs1 == this.Eyeballs2) && (drink.Eyeballs2 == this.Eyeballs3) && (drink.Eyeballs3 == this.Eyeballs1);
            bool order5 = (drink.Eyeballs1 == this.Eyeballs3) && (drink.Eyeballs2 == this.Eyeballs2) && (drink.Eyeballs3 == this.Eyeballs3);
            bool order6 = (drink.Eyeballs1 == this.Eyeballs3) && (drink.Eyeballs2 == this.Eyeballs1) && (drink.Eyeballs3 == this.Eyeballs2);
            eyes = order1 || order2 || order3 || order4 || order5 || order6;
        }

        return eyes;
    }

    public bool compareToCurrentDrink(currDrink drink)
    {
        bool sameDrink = compareEyes(drink);

        sameDrink = sameDrink && (drink.Gemstones == this.Gemstones);
        sameDrink = sameDrink && (drink.Fruits == this.Fruits);
        sameDrink = sameDrink && (drink.Fingers == this.Fingers);
        sameDrink = sameDrink && (drink.Hearts == this.Hearts);
        sameDrink = sameDrink && (drink.Tentacles == this.Tentacles);
        sameDrink = sameDrink && (drink.LiquidBase == this.LiquidBase);
        sameDrink = sameDrink && (drink.hasBeenJuiced == this.hasBeenJuiced);
        sameDrink = sameDrink && (drink.hasBeenShaken == this.hasBeenShaken);
        sameDrink = sameDrink && (drink.hasBeenStirred == this.hasBeenStirred);

        return sameDrink;
    }
}
