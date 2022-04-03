using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSlide : MonoBehaviour
{
    // Start is called before the first frame update
    Transform destination;
    public Transform originalPosition;

    public SpriteRenderer glass;
    public SpriteRenderer drink;
    public bool atDestination;
    private float moveTimer = 0;

    public AudioSource glassBreaking;

    // hard code 5 seconds
    private float duration = 14f;

    void Start()
    {

        originalPosition = this.transform;
        atDestination = true;
        glass.enabled = false;
        drink.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!atDestination)
        {
            moveTimer += Time.deltaTime;
            this.transform.position = Vector2.Lerp(transform.position, destination.transform.position, moveTimer / duration);

            if (moveTimer / duration >= .05) {
                moveTimer = 0;
                atDestination = true;
                glassBreaking.Play();
                glass.enabled = false;
                drink.enabled = false;
                resetPosition();
                
            }
        }
    }

    public void setDestination(Transform destination)
    {
        this.destination = destination;
        glass.enabled = true;
        drink.enabled = true;
        atDestination = false;
    }

    public void resetPosition()
    {
        this.transform.position = new Vector3(7, -.54f, 0);
    }
}
