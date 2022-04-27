using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSlide : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform destination;
    public Transform originalPosition;

    public SpriteRenderer glass;
    public SpriteRenderer drink;

    public GameObject currDrink;
    public GameObject gameHandler;

    public bool atDestination;
    private float moveTimer = 0;

    public AudioSource glassBreaking;
    public Transform offscreen;

    // hard code 5 seconds
    private float duration = 100f;

    void Start()
    {

        originalPosition = this.transform;
        atDestination = true;
        //glass.enabled = false;
        //drink.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!atDestination)
        {
            Debug.Log("Moving to dest");
            moveTimer += Time.deltaTime;
            this.transform.position = Vector2.Lerp(transform.position, destination.position, moveTimer / duration);
            //Debug.Log(moveTimer);

            //Debug.Log(transform.position.x - destination.position.x);

            if (moveTimer / duration >= 0.1f || (transform.position.x - destination.position.x < 0.8f)) {
                moveTimer = 0;
                atDestination = true;

                if (destination.position == offscreen.position)
                {
                    glassBreaking.Play();
                }
                //glass.enabled = false;
                //drink.enabled = false;

                currDrink.GetComponent<currDrink>().clearDrink();
                resetPosition();
                gameHandler.GetComponent<GameHandler>().drinkPrimed = true;
            }
        }
    }

    public void setDestination(Transform destination)
    {
        Debug.Log("Setting destination");

        this.destination = destination;



        if (this.destination == destination) {
            Debug.Log("Updated");
        }
        //glass.enabled = true;
        //drink.enabled = true;
        atDestination = false;
    }

    public void resetPosition()
    {
        this.transform.position = new Vector3(6.48f, -.54f, 0);
    }
}
