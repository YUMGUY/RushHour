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

    private void Awake()
    {
        print("yo this should be first");
        textbox.text = "New Text";
    }

    private void OnEnable()
    {
        // can be activated also by the make Drink function later on
        print("this should be second");
        textbox.gameObject.SetActive(true);
        compare.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        //textbox.text = "";
        compare.text = "";
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
                if(compare.text[count - 1] != textbox.text[count - 1])
                {
                    print("not pog");
                    compare.text = "";
                }

                if(count == textbox.text.Length)
                {
                    print("yo you did it");
                    textbox.gameObject.SetActive(false);
                    compare.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                }
               
            }
        }
        
    }


}
