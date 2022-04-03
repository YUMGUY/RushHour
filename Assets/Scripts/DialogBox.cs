using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    // Start is called before the first frame update
    public MonsterDrink drinkOrder;

    // Possible Sprites to choose from
    public Sprite size2;
    public Sprite size3;
    public Sprite size4;
    public Sprite size5;

    // List of SpriteRenderers representing the slots
    SpriteRenderer[] iconSlots;

    // All possible icons - FIX LATER

    // Eyes
    public Sprite purpleEye;
    public Sprite blueEye;
    public Sprite greenEye;

    // Gems
    public Sprite pearl;
    public Sprite diamond;
    public Sprite heartGem;

    // Fruits
    public Sprite firefruit;
    public Sprite icefruit;
    public Sprite electricfruit;

    // Prehensile things and a heart
    public Sprite finger;
    public Sprite heart;
    public Sprite tentacle;

    // Bases
    public Sprite lavaSlime;
    public Sprite blood;
    public Sprite brainjuice;
    public Sprite tonic;

    // Mixing Methods
    public Sprite shaken;
    public Sprite stirred;
    public Sprite juiced;

    private int numberInOrder;
    void Start()
    {
        setupIconSlots();

    }

    public void updateBubble(MonsterDrink order)
    {
        drinkOrder = order;
        // number we've already added to the speech bubble to keep track of position
        numberInOrder = 1;

        // set the correct size
        if (drinkOrder.size == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = size2;
        }
        else if (drinkOrder.size == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = size3;
        }
        else if (drinkOrder.size == 4)
        {
            this.GetComponent<SpriteRenderer>().sprite = size4;
        }
        else if (drinkOrder.size == 5)
        {
            this.GetComponent<SpriteRenderer>().sprite = size5;
        }

        // add icons
        // EYE 1
        if (drinkOrder.Eyeballs1 != 0)
        {
            if (drinkOrder.Eyeballs1 == 1)
            {
                // add blue eyes
                iconSlots[numberInOrder].sprite = blueEye;
            }
            else if (drinkOrder.Eyeballs1 == 2)
            {
                // add green eyes
                iconSlots[numberInOrder].sprite = greenEye;
            }
            else
            {
                // add purple eyes
                iconSlots[numberInOrder].sprite = purpleEye;
            }
            numberInOrder++;
        }

        // EYE 2
        if (drinkOrder.Eyeballs2 != 0)
        {
            if (drinkOrder.Eyeballs2 == 1)
            {
                // add blue icon sprite
                iconSlots[numberInOrder].sprite = blueEye;
            }
            else if (drinkOrder.Eyeballs2 == 2)
            {
                // add green eyes
                iconSlots[numberInOrder].sprite = greenEye;
            }
            else
            {
                // add brown eyes
                iconSlots[numberInOrder].sprite = purpleEye;
            }
            numberInOrder++;
        }

        // EYE 3
        if (drinkOrder.Eyeballs3 != 0)
        {
            if (drinkOrder.Eyeballs3 == 1)
            {
                // add blue icon sprite
                iconSlots[numberInOrder].sprite = blueEye;
            }
            else if (drinkOrder.Eyeballs3 == 2)
            {
                // add green eyes
                iconSlots[numberInOrder].sprite = greenEye;
            }
            else
            {
                // add brown eyes
                iconSlots[numberInOrder].sprite = purpleEye;
            }
            numberInOrder++;
        }


        // GEMSTONES
        if (drinkOrder.Gemstones != 0)
        {
            if (drinkOrder.Gemstones == 1)
            {
                // add pearls
                iconSlots[numberInOrder].sprite = pearl;
            }
            else if (drinkOrder.Gemstones == 2)
            {
                // add diamonds
                iconSlots[numberInOrder].sprite = diamond;
            }
            else
            {
                // add heart gemstones
                iconSlots[numberInOrder].sprite = heartGem;

            }
            numberInOrder++;
        }

        // FRUITS
        if (drinkOrder.Fruits != 0)
        {
            if (drinkOrder.Fruits == 1)
            {
                // add fire fruit
                iconSlots[numberInOrder].sprite = firefruit;

            }
            else if (drinkOrder.Fruits == 2)
            {
                // add ice fruit
                iconSlots[numberInOrder].sprite = icefruit;
            }
            else
            {
                // add electric fruit
                iconSlots[numberInOrder].sprite = electricfruit;
            }
            numberInOrder++;
        }

        // FINGERS
        if (drinkOrder.Fingers == true)
        {
            // add finger icon
            iconSlots[numberInOrder].sprite = finger;
            numberInOrder++;
        }

        // HEARTS
        if (drinkOrder.Hearts == true)
        {
            // add heart icon
            iconSlots[numberInOrder].sprite = heart;
            numberInOrder++;
        }


        // TENTACLES
        if (drinkOrder.Tentacles == true)
        {
            // add tentacle icon
            iconSlots[numberInOrder].sprite = tentacle;
            numberInOrder++;
        }

        // LIQUID BASE
        if (drinkOrder.LiquidBase == 1)
        {
            // add lava slime
            iconSlots[numberInOrder].sprite = lavaSlime;
            numberInOrder++;
        }
        else if (drinkOrder.LiquidBase == 2)
        {
            // add blood
            iconSlots[numberInOrder].sprite = blood;
            numberInOrder++;
        }
        else if (drinkOrder.LiquidBase == 3)
        {
            // add brain juice
            iconSlots[numberInOrder].sprite = brainjuice;
            numberInOrder++;
        }
        else if (drinkOrder.LiquidBase == 4)
        {
            // add tonic water
            iconSlots[numberInOrder].sprite = tonic;
            numberInOrder++;
        }

        // Mixing Methods
        if (drinkOrder.hasBeenJuiced)
        {
            iconSlots[numberInOrder].sprite = juiced;
            numberInOrder++;
        }

        if (drinkOrder.hasBeenShaken)
        {
            iconSlots[numberInOrder].sprite = shaken;
            numberInOrder++;
        }

        if (drinkOrder.hasBeenStirred)
        {
            iconSlots[numberInOrder].sprite = stirred;
            numberInOrder++;
        }
    }

    void setupIconSlots()
    {
        // MAKE SURE ALL SPRITE ICON SLOTS ARE CHILDREN OF THE DIALOG BOX
        iconSlots = this.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
        {

        }
    }
