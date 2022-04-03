using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currDrink : MonoBehaviour
{
    [SerializeField] ExplosionFlash _image = null;

    private List<GameObject> storedIngreds;
    private bool addedLiquid = false;
    public GameObject cameraRef;

    [Header("Current Ingredients")]

    public int Eyeballs1 = 0; //0 = no eyes, 1 = blue eyes, 2 = green eyes, 3 = brown eyes
    public int Eyeballs2 = 0;
    public int Eyeballs3 = 0;
    public int Gemstones = 0; //0 = no gems, 1 = pearls, 2 = diamonds, 3 = heart gems
    public int Fruits = 0; //0 = no fruit, 1 = firefruit, 2 = icefruit, 3 = elecfruit
    public bool Fingers = false; //false = no finger
    public bool Hearts = false; //false = no hearts
    public bool Tentacles = false; //flase = no tentacles
    public int LiquidBase = 0; //0 = empty glass, 1 = lava slime, 2 = blood, 3 = brainjuice, 4 = tonic water

    // Start is called before the first frame update
    void Start()
    {
        storedIngreds = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {

            foreach (GameObject storedIngred in storedIngreds)
            {
                Destroy(storedIngred.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            drinkExplosion();
        }
        Debug.Log(addedLiquid);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ingredient Added");
        try
        {
            switch (collision.GetComponent<Ingredient>().PrimaryID)
            {
                case "Eyeball":
                    if (Eyeballs1 == 0)
                    {
                        switch (collision.GetComponent<Ingredient>().SecondaryID)
                        {
                            case "Blue":
                                Eyeballs1 = 1;
                                break;
                            case "Green":
                                Eyeballs1 = 2;
                                break;
                            case "Purple":
                                Eyeballs1 = 3;
                                break;
                            default:
                                Eyeballs1 = 0;
                                break;
                        }
                    }
                    else if (Eyeballs2 == 0)
                    {
                        switch (collision.GetComponent<Ingredient>().SecondaryID)
                        {
                            case "Blue":
                                Eyeballs2 = 1;
                                break;
                            case "Green":
                                Eyeballs2 = 2;
                                break;
                            case "Purple":
                                Eyeballs2 = 3;
                                break;
                            default:
                                Eyeballs2 = 0;
                                break;
                        }
                    }
                    else if (Eyeballs3 == 0)
                    {
                        switch (collision.GetComponent<Ingredient>().SecondaryID)
                        {
                            case "Blue":
                                Eyeballs3 = 1;
                                break;
                            case "Green":
                                Eyeballs3 = 2;
                                break;
                            case "Purple":
                                Eyeballs3 = 3;
                                break;
                            default:
                                Eyeballs3 = 0;
                                break;
                        }
                    }
                    else
                    {
                        //ADDED TOO MANY EYEBALLS ; EXPLODE
                        drinkExplosion();
                    }
                    break;
                case "Gemstone":
                    if (Gemstones == 0)
                    {
                        switch (collision.GetComponent<Ingredient>().SecondaryID)
                        {
                            case "Pearl":
                                Gemstones = 1;
                                break;
                            case "Diamond":
                                Gemstones = 2;
                                break;
                            case "Heart":
                                Gemstones = 3;
                                break;
                            default:
                                Gemstones = 0;
                                break;
                        }
                    }
                    else
                    {
                        //ADDED TOO MANY
                        drinkExplosion();
                    }
                    break;
                case "Fruit":
                    if (Fruits == 0)
                    {
                        switch (collision.GetComponent<Ingredient>().SecondaryID)
                        {
                            case "Fire":
                                Fruits = 1;
                                break;
                            case "Ice":
                                Fruits = 2;
                                break;
                            case "Elec":
                                Fruits = 3;
                                break;
                            default:
                                Fruits = 0;
                                break;
                        }
                    }
                    else
                    {
                        //ADDED TOO MANY
                        drinkExplosion();
                    }
                    break;
                case "Finger":
                    if (!Fingers)
                    {
                        Fingers = true;
                    }
                    else
                    {
                        //ADDED TOO MANY
                        drinkExplosion();
                    }
                    break;
                case "Heart":
                    if (!Hearts)
                    {
                        Hearts = true;
                    }
                    else
                    {
                        //ADDED TOO MANY
                        drinkExplosion();
                    }
                    break;
                case "Tentacle":
                    if (!Tentacles)
                    {
                        Tentacles = true;
                    }
                    else
                    {
                        //ADDED TOO MANY
                        drinkExplosion();
                    }
                    break;
                case "Liquid":
                    addedLiquid = true;
                    if (LiquidBase == 0)
                    {
                        
                        switch (collision.GetComponent<Ingredient>().SecondaryID)
                        {
                            case "Lava":
                                LiquidBase = 1;
                                break;
                            case "Blood":
                                LiquidBase = 2;
                                break;
                            case "Brain":
                                LiquidBase = 3;
                                break;
                            case "Water":
                                LiquidBase = 4;
                                break;
                            default:
                                LiquidBase = 0;
                                break;
                        }
                        
                    }
                    else
                    {
                        //ADDED TOO MANY
                        drinkExplosion();
                        addedLiquid = true;
                    }
                    break;

            }
        }
        catch
        {
            Debug.Log("Object added was not an ingredient");
        }


        if (!addedLiquid)
        {
            collision.gameObject.SetActive(false);
            storedIngreds.Add(collision.gameObject);
        }
        else {
            collision.GetComponent<DragAndDrop_Alt>().returnHome();
            addedLiquid = false;
        }
        
        

    }

    public void drinkExplosion() {

        _image.StartFlash(0.25f, Color.red);
        if (cameraRef != null) {
            try
            {
                cameraRef.GetComponent<ScreenShake>().TriggerShake();
            }
            catch {
                Debug.Log("ERROR: The ScreenShake script needs to be attached to the camera obj.");
            }
        }
        clearDrink();
    }

    public void clearDrink()
    {
        addedLiquid = false;
        Eyeballs1 = 0; //0 = no eyes, 1 = blue eyes, 2 = green eyes, 3 = brown eyes
        Eyeballs2 = 0;
        Eyeballs3 = 0;
        Gemstones = 0; //0 = no gems, 1 = pearls, 2 = diamonds, 3 = heart gems
        Fruits = 0; //0 = no fruit, 1 = firefruit, 2 = icefruit, 3 = elecfruit
        Fingers = false; //false = no finger
        Hearts = false; //false = no hearts
        Tentacles = false; //flase = no tentacles
        LiquidBase = 0; //0 = empty glass, 1 = lava slime, 2 = blood, 3 = brainjuice, 4 = tonic water
    }

}
