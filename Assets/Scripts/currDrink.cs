using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currDrink : MonoBehaviour
{
    [SerializeField] ExplosionFlash _image = null;

    private List<GameObject> storedIngreds;
    private bool addedLiquid = false;
    public GameObject cameraRef;

    [Header("LiquidObjs")]
    public GameObject LavaLiq;
    public GameObject BloodLiq;
    public GameObject BrainLiq;
    public GameObject WaterLiq;

    [Header("SingleIngredSprites")]
    public Sprite TentacleSpr;
    public Sprite FingerSprFront;
    public Sprite FingerSprBack;
    public Sprite HeartSpr;

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

    [Header("Current Mixing Status")]

    public bool hasBeenStirred = false;
    public bool hasBeenShaken = false;
    public bool hasBeenJuiced = false;

    // Start is called before the first frame update
    void Start()
    {
        storedIngreds = new List<GameObject>();
        //transform.GetChild(11).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Holding Left Mouse Down");
            cameraRef.GetComponent<MoveCamera>().canMove = false;
        }
        if (Input.GetMouseButtonUp(0)) {
            cameraRef.GetComponent<MoveCamera>().canMove = true;
            foreach (GameObject storedIngred in storedIngreds)
            {
                Destroy(storedIngred.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            drinkExplosion();
        }
        //Debug.Log(addedLiquid);

        if (LiquidBase == 0)
        {
            transform.GetChild(5).GetComponent<BobUpAndDown>().speed = 0.0f;
            transform.GetChild(6).GetComponent<BobUpAndDown>().speed = 0.0f;
        }
        else {
            transform.GetChild(5).GetComponent<BobUpAndDown>().speed = 3.0f;
            transform.GetChild(6).GetComponent<BobUpAndDown>().speed = 3.0f;
        }
        if (Eyeballs1 != 0)
        {
            transform.GetChild(11).gameObject.SetActive(true);
        }
        else {
            transform.GetChild(11).gameObject.SetActive(false);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Sprite sprite;
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
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Green":
                                Eyeballs1 = 2;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Purple":
                                Eyeballs1 = 3;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sprite;
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
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Green":
                                Eyeballs2 = 2;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Purple":
                                Eyeballs2 = 3;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = sprite;
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
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Green":
                                Eyeballs3 = 2;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Purple":
                                Eyeballs3 = 3;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            default:
                                Eyeballs3 = 0;
                                break;
                        }
                    }
                    else
                    {
                        //ADDED TOO MANY EYEBALLS ; EXPLODE
                        //Debug.Log("Too many eyes");
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
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Diamond":
                                Gemstones = 2;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Heart":
                                Gemstones = 3;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = sprite;
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
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Ice":
                                Fruits = 2;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Elec":
                                Fruits = 3;
                                sprite = collision.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = sprite;
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


                        Sprite sprite1 = FingerSprFront;
                        Sprite sprite2 = FingerSprBack;

                        GameObject fingerFront = GameObject.Find("FingerSlot");
                        fingerFront.GetComponent<SpriteRenderer>().sprite = sprite1;

                        GameObject fingerBack = GameObject.Find("BackOfFinger");
                        fingerBack.GetComponent<SpriteRenderer>().sprite = sprite2; 
                        
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
                        sprite = HeartSpr;
                        transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = sprite;

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
                        sprite = TentacleSpr;
                        transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = sprite;
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
                                sprite = LavaLiq.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Blood":
                                LiquidBase = 2;
                                sprite = BloodLiq.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Brain":
                                LiquidBase = 3;
                                sprite = BrainLiq.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = sprite;
                                break;
                            case "Water":
                                LiquidBase = 4;
                                sprite = WaterLiq.GetComponent<SpriteRenderer>().sprite;
                                transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = sprite;
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
            collision.GetComponent<Ingredient>().addToDrink();
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
        //Debug.Log("Tried to explode");
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

        hasBeenJuiced = false; 
        hasBeenShaken = false;
        hasBeenStirred = false;

        for (int i = 1; i < 10; i++) {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = null;

        }
        GameObject.Find("BackOfFinger").GetComponent<SpriteRenderer>().sprite = null;
    }

}
