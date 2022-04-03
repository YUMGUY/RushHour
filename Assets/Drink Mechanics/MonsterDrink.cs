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

    public MonsterDrink()
    {
        Eyeballs1 = Random.Range(0, 3);
        Eyeballs2 = Random.Range(0, 3);
        Eyeballs3 = Random.Range(0, 3);
        Gemstones = Random.Range(0, 3);
        Fruits = Random.Range(0, 3);
        Fingers = Random.Range(0, 1) == 1 ? true : false;
        Hearts = Random.Range(0, 1) == 1 ? true : false;
        Tentacles = Random.Range(0, 1) == 1 ? true : false;
        LiquidBase = Random.Range(0, 3);
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
