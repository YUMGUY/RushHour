using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pointA;
    public Transform pointB;

   
    private Vector3 vect = Vector3.zero;
    public bool originalscene = true;

    public bool moveToScene2;
    public bool moveToScene1;


    public float cooldown;

    public bool canMove;
    // particle system

    void Start()
    {
        moveToScene2 = false;
        moveToScene1 = false;
        originalscene = true;
        cooldown = 0;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {


            cooldown -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftShift) && originalscene == true && cooldown <= 0)
            {
                moveToScene2 = true;
                moveToScene1 = false;
                cooldown = .5f;
            }


            else if (moveToScene2 == true && originalscene == true)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, pointB.position, .5f);
                if (transform.position.y <= pointB.position.y)
                {
                    originalscene = false;
                }
            }

            else
            {

            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && !originalscene && cooldown <= 0)
            {
                moveToScene1 = true;
                moveToScene2 = false;
                cooldown = .5f;

            }

            else if (moveToScene1 == true && originalscene == false)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, pointA.position, .5f);
                if (transform.position.y >= pointA.position.y)
                {
                    originalscene = true;
                }
            }

            else
            {

            }
        } // end of the if statement

    }
}
