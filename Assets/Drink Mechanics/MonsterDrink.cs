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

    public int size = 0;

    public MonsterDrink()
    {

        // everything needs a liquor
        LiquidBase = Random.Range(1, 4);
        size++;

        int orderSize = Random.Range(2, 5);

        while(size != orderSize)
        {
            int randomSelection = Random.Range(0, 5);

            if(randomSelection == 0)
            {
                if(Eyeballs1 == 0)
                {
                    Eyeballs1 = Random.Range(1, 3);
                    size++;
                } else if(Eyeballs2 == 0)
                {
                    Eyeballs2 = Random.Range(1, 3);
                    size++;
                } else
                {
                    Eyeballs3 = Random.Range(0, 3);
                    size++;
                }
            }

            else if(randomSelection == 1 && Gemstones == 0)
            {
                Gemstones = Random.Range(1, 3);
                size++;
            }

            else if (randomSelection == 2 && Fruits == 0)
            {
                Fruits = Random.Range(1, 3);
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
    }

    public bool compareToCurrentDrink(currDrink drink)
    {
        bool sameDrink = true;

        sameDrink = sameDrink && (drink.Eyeballs1 == this.Eyeballs1);
        sameDrink = sameDrink && (drink.Eyeballs2 == this.Eyeballs2);
        sameDrink = sameDrink && (drink.Eyeballs3 == this.Eyeballs3);
        sameDrink = sameDrink && (drink.Gemstones == this.Gemstones);
        sameDrink = sameDrink && (drink.Fruits == this.Fruits);
        sameDrink = sameDrink && (drink.Fingers == this.Fingers);
        sameDrink = sameDrink && (drink.Hearts == this.Hearts);
        sameDrink = sameDrink && (drink.Tentacles == this.Tentacles);
        sameDrink = sameDrink && (drink.LiquidBase == this.LiquidBase);

        return sameDrink;
    }
}
