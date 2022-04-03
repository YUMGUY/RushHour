using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class shakingMechanic : MonoBehaviour
{
    // Start is called before the first frame update
    public Image imageShake;
    public char[] upShakeKey;    // t y
    public char[] downShakeKey;  // g h

    public char playerShakeUp;
    public char playerShakeDown;
    public bool shake;


    public float currentFillShake;
    public float maxFillShake;

    public float incrementFillShake;
    public float decreaseFillShake;
    public float cooldownMashShake;

    public float limboTimeShake;

    public TextMeshProUGUI textup;
    public TextMeshProUGUI textdown;
    public TextMeshProUGUI flashingText;

    public GameObject shakingImage;

    public MoveCamera movingCamera;
    void Start()
    {
        StartCoroutine(flashText());
    }

    private void OnEnable()
    {
        shake = false;
        int index = Random.Range(0, upShakeKey.Length);
        playerShakeDown = downShakeKey[index];
        playerShakeUp = upShakeKey[index];


        textup.text = playerShakeUp.ToString().ToUpper();
        textdown.text = playerShakeDown.ToString().ToUpper();
        shakingImage.SetActive(true);


        movingCamera.canMove = false;
    }

    // enable player to press shift again
    private void OnDisable()
    {
        shakingImage.SetActive(false);
        currentFillShake = 0;
        movingCamera.canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        changeFillShake(); 
        Max_MinValueShake();
        Shake(playerShakeUp, playerShakeDown);
        ReduceFillShake();

        imageShake.color = Color.Lerp(Color.white, Color.green, .5f*imageShake.fillAmount);

        // shake left and right using rotation
       
    }

    public void Shake(char up, char down)
    {
        // shake false is shake up, shake true is shake down
        if (shake == false)
           
        {   
            textup.color = Color.red;
            //print("go up");
            switch(up) {
                case 't':
                    if(Input.GetKeyDown(KeyCode.T))
                    {
                        currentFillShake += incrementFillShake;
                        cooldownMashShake = 0;
                        textup.color = Color.white;
                        shake = true;
                        
                    }
                    break;
                case 'y':
                    if(Input.GetKeyDown(KeyCode.Y))
                    {
                        currentFillShake += incrementFillShake;
                        cooldownMashShake = 0;
                        textup.color = Color.white;
                        shake = true;
                    }
                    break;
                }

          
        }

        else if (shake == true)
        {
            textdown.color = Color.red;
           // print("shake is true");
            switch(down)
            {
                case 'g':
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        currentFillShake += incrementFillShake;
                        cooldownMashShake = 0;
                        textdown.color = Color.white;
                        shake = false;
                    }
                     break;

                case 'h':
                    if (Input.GetKeyDown(KeyCode.H))
                    {
                        currentFillShake += incrementFillShake;
                        cooldownMashShake = 0;
                        textdown.color = Color.white;
                        shake = false;
                    }
                    break;
            }
           
                
        }



    }

    public void changeFillShake()
    {
        imageShake.fillAmount = currentFillShake / maxFillShake;
    }

    public void ReduceFillShake()
    {
        cooldownMashShake += 1;
        if (cooldownMashShake > limboTimeShake)
        {
            currentFillShake -= decreaseFillShake;
        }
    }
    public void Max_MinValueShake()
    {
        if (currentFillShake < 0)
        {
            currentFillShake = 0;
        }

        else if (currentFillShake >= maxFillShake)
        {
            currentFillShake = maxFillShake;
            print("hurray you finished shaking");

            this.gameObject.SetActive(false);
        }
    }


    // coroutine for flashing text

    private IEnumerator flashText()
    {
        while(true)
        {
        flashingText.color = Color.red;
        yield return new WaitForSeconds(.2f);
        flashingText.color = Color.white;
            yield return new WaitForSeconds(.2f);
            yield return null;

        }
       
       // yield return null;
    }
}
