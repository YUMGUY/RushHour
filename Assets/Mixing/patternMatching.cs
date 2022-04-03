using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class patternMatching : MonoBehaviour
{
    // Start is called before the first frame update
    //public string patterns;
    public Text textbox;
    public Text compare;
    private bool flag = false;

    public string[] patterns;

    public MoveCamera movingCamera;
    public currDrink currentDrink;
    private void Awake()
    {
        //int index = Random.Range(0, patterns.Length);

        //print("yo this should be first");
        //textbox.text = patterns[index];
    }

    private void OnEnable()
    {
        // can be activated also by the make Drink function later on
        int index = Random.Range(0, patterns.Length);
        currentDrink.stir.Play();
      //  print("yo this should be first");
        textbox.text = patterns[index];
       // print("this should be second");
        textbox.gameObject.SetActive(true);
        compare.gameObject.SetActive(true);
        movingCamera.canMove = false;
        // INSTEAD OF TEXT
        // instantitate the sprite pattern object, prefabs with children that have the sprites with index followed

    }

    private void OnDisable()
    {
        //textbox.text = "";
        compare.text = "";
        textbox.gameObject.SetActive(false);
        compare.gameObject.SetActive(false);
        movingCamera.canMove = true;
        
        flag = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the first letter, ignore any bad input at first as to start the pattern fair and square

        
        if(flag == false)
        {
            foreach(char c in Input.inputString)
            {
            
                if(c == textbox.text[0] && flag == false)
                {
                    compare.text += c;
                    flag = true;
                }
            }
        }

        else
        {
            foreach(char letter in Input.inputString)
            {
                compare.text += letter;
                int count = compare.text.Length;
                print(count);
                // CHANGE TO SPRITE MECHANICS
                /* 
                 SPRITE W TO SPRITE W PRESSED, instead of text string, we do sprite array
                 */
                if(compare.text[count - 1] != textbox.text[count - 1])
                {
                    print("not pog");
                    compare.text = "";
                    break;
                }

                // IMAGINE IF THERE WAS A SPRITE ARRAY


                if(count == textbox.text.Length)
                {
                    print("yo you did it");
                    currentDrink.stir.Stop();
                    currentDrink.hasBeenStirred = true;
                    textbox.gameObject.SetActive(false);
                    compare.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                }
               
            }
        }
        
    }


}
