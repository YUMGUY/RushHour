using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class juicingMechanics : MonoBehaviour
{
    public Image image;
    public char[] mashiNPUTS;
    public char playerRequiredInput;


    public float currentFill;
    public float maxFill;

    public float incrementFill;
    public float decreaseFill;
    public float cooldownMash;

    public float limboTime;

    public TextMeshProUGUI textMash;

    public GameObject backgroundMash;
    public MoveCamera moveCameraMash;
    public currDrink currentDrink;

    public GameObject refToClearButton;

    public GameObject toolTip;

    public GameObject AlertFlash;

    // Start is called before the first frame update
    void Start()
    {
        
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
            int index = Random.Range(0, mashiNPUTS.Length);
            playerRequiredInput = mashiNPUTS[index];
            textMash.text = playerRequiredInput.ToString().ToUpper();
            backgroundMash.SetActive(true);

            toolTip.SetActive(true);

            moveCameraMash.canMove = false;

            refToClearButton.gameObject.SetActive(true);
        }
        

    }

    private void OnDisable()
    {
        currentFill = 0;
        backgroundMash.SetActive(false);
        moveCameraMash.canMove = true;
        toolTip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        changeFill();
        Max_MinValue();
        Smashing(playerRequiredInput);
        ReduceFill();

        // CHANGE COLOR.GREEN TO
        image.color = Color.Lerp(Color.white, Color.green, .5f*image.fillAmount);

        // GameObject currentDrink = FindGamobjectTag
        // currentdrink.trasnform.scale = ping pong
    }

    public void Smashing(char letter)
    {
       // print("this is the letter " + letter);
        // for all 4 letters that we can smash with
        switch(letter)
        {
            case 's':
             //   print(letter);
                if(Input.GetKeyDown(KeyCode.S))
                {
                    currentFill += incrementFill;
                    cooldownMash = 0;
                }
                break;
            case 'd':
              //  print(letter);
                if(Input.GetKeyDown(KeyCode.D)) {
                    currentFill += incrementFill;
                    cooldownMash = 0;
                }
                break;

            case 'f':
              //  print(letter);
                if(Input.GetKeyDown(KeyCode.F))
                {
                    currentFill += incrementFill;
                    cooldownMash = 0;
                }
                break;
               // print(letter);
            case 'g':
                if(Input.GetKeyDown(KeyCode.G))
                {
                    currentFill += incrementFill;
                    cooldownMash = 0;
                }
                break;
        }



    }


    public void changeFill()
    {
        image.fillAmount = currentFill / maxFill;
    }

    public void ReduceFill()
    {
        cooldownMash += 1;
        if(cooldownMash > limboTime)
        {
            currentFill -= decreaseFill;
        }
    }

    public void Max_MinValue()
    {
        if(currentFill < 0)
        {
            currentFill = 0;
        }

        else if(currentFill >= maxFill)
        {
            currentFill = maxFill;
            currentDrink.hasBeenJuiced = true;
            print("hurray you finished");

            refToClearButton.gameObject.SetActive(false);

            this.gameObject.SetActive(false);
        }
    }
}
