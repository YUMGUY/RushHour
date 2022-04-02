using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeWaiting;
    // Drink drink

    void Start()
    {
        timeWaiting = 0;
        // drink = Drink();
        // drink.randomizeKeys();
    }

    public void increaseTimeWaiting(float additionalTime)
    {
        timeWaiting += additionalTime;
    }

    public float getTimeWaiting()
    {
        return timeWaiting;
    }
}
