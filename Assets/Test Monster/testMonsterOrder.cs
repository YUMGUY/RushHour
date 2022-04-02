using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMonsterOrder : MonoBehaviour
{
    // Start is called before the first frame update

    public MonsterDrink[] orders;

   // public string[] monsterIngredients;


    // use the gamemanager 
   public Dictionary<string, int> ingredients;

    void Start()
    {
        // non-random order( a set formula drink)
        ingredients = new Dictionary<string, int>();
        ingredients.Add("eyeball", orders[0].eyeballs);

        foreach (KeyValuePair<string, int> key in ingredients)
        {
            print(key.Key + ", " + key.Value);

            if(key.ToString() == "")
            {

            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {   
        // if
        // game manager.playerdrink.eyeballs == 
        
    }
}
