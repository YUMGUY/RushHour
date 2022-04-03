using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pointA;
    public Transform pointB;

    private Vector3 vect = Vector3.zero;
    private bool originalscene = true;

    private bool moveToScene2;
    private bool moveToScene1;

  

    // particle system

    void Start()
    {
        moveToScene2 = false;
        moveToScene1 = false;
        originalscene = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)&& originalscene)
        {
            moveToScene2 = true;
            moveToScene1 = false;
        }
        
        

        if(moveToScene2 == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, pointB.position, .5f);
            if(transform.position.y <= pointB.position.y)
            {
                originalscene = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && !originalscene)
            {
            moveToScene1 = true;
            moveToScene2 = false;
           
            }

        if(moveToScene1 == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, pointA.position, .5f);
            if (transform.position.y >= pointA.position.y)
            {
                originalscene = true;
            }
        }
        
    }
}
