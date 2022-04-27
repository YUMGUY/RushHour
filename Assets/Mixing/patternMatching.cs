using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class patternMatching : MonoBehaviour
{
    // Start is called before the first frame update
    //public string patterns;
    //public Text textbox;
    public GameObject textbox;
    //public Text compare;
    public GameObject compare;
    private bool flag = false;

    private string textboxStr;
    private string compareStr;
    public string[] patterns;

    public MoveCamera movingCamera;
    public currDrink currentDrink;

    public GameObject refToClearButton;

    public GameObject parentKey;

    public GameObject toolTip;

    public GameObject AlertFlash;
    private void Awake()
    {
        //int index = Random.Range(0, patterns.Length);

        //print("yo this should be first");
        //textbox.text = patterns[index];
    }

    private void OnEnable()
    {
        if (currentDrink.LiquidBase == 0)
        {
            AlertFlash.GetComponent<FlashAlert>().StartAlert("Add Liquid First!", 0, 50, Vector3.zero, Color.green);
            this.gameObject.SetActive(false);
            refToClearButton.gameObject.SetActive(false);
        }
        else {
            // can be activated also by the make Drink function later on
            int index = Random.Range(0, patterns.Length);
            parentKey.SetActive(true);
            currentDrink.stir.Play();

            //  print("yo this should be first");
            textbox.GetComponent<TMPro.TextMeshProUGUI>().text = patterns[index];
            textboxStr = textbox.GetComponent<TMPro.TextMeshProUGUI>().text;
            //compareStr = compare.GetComponent<TMPro.TextMeshProUGUI>().text;
            // print("this should be second");
            textbox.SetActive(true);
            compare.SetActive(true);
            movingCamera.canMove = false;
            // INSTEAD OF TEXT
            // instantitate the sprite pattern object, prefabs with children that have the sprites with index followed
            toolTip.SetActive(true);

            refToClearButton.gameObject.SetActive(true);
        }
        

    }

    private void OnDisable()
    {
        //textbox.text = "";
        compare.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        textbox.SetActive(false);
        compare.SetActive(false);
        movingCamera.canMove = true;
        parentKey.SetActive(false);
        toolTip.SetActive(false);
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
            
                if(c == textboxStr[0] && flag == false)
                {
                    compare.GetComponent<TMPro.TextMeshProUGUI>().text += c;
                    flag = true;
                }
            }
        }

        else
        {
            foreach(char letter in Input.inputString)
            {
                compare.GetComponent<TMPro.TextMeshProUGUI>().text += letter;
                int count = compare.GetComponent<TMPro.TextMeshProUGUI>().text.Length;
                print(count);
                // CHANGE TO SPRITE MECHANICS
                /* 
                 SPRITE W TO SPRITE W PRESSED, instead of text string, we do sprite array
                 */
                if(compare.GetComponent<TMPro.TextMeshProUGUI>().text[count - 1] != textboxStr[count - 1])
                {
                    print("not pog");
                    compare.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                    break;
                }

                // IMAGINE IF THERE WAS A SPRITE ARRAY


                if(count == textboxStr.Length)
                {
                    print("yo you did it");
                    currentDrink.stir.Stop();

                    refToClearButton.gameObject.SetActive(false); 

                    currentDrink.hasBeenStirred = true;
                    textbox.gameObject.SetActive(false);
                    compare.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                }
               
            }
        }
        
    }


}
