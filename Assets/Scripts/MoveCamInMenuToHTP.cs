using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamInMenuToHTP : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;

    public GameObject cameraRef;

    private Vector3 vect = Vector3.zero;
    public bool originalscene = true;

    public bool atScene2;
    public bool atScene1;

    public bool startTransition = false;

    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        atScene2 = false;
        atScene1 = true;

        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTransition) {

            if (atScene1)
            {
                //Debug.Log("Currently at Main Menu");
                while (cameraRef.transform.position.y != pointB.position.y)
                {
                    //Debug.Log("Traveling to B");
                    cameraRef.transform.position = Vector3.MoveTowards(cameraRef.transform.position, pointB.position, 0.1f);
                }
                atScene1 = false;
                atScene2 = true;
                startTransition = false;
            }
            else if (atScene2)
            {
                //Debug.Log("Currently at Sub Menu");
                //Debug.Log(pointA.position.y + " vs. " + cameraRef.transform.position.y);
                while (cameraRef.transform.position.y != pointA.position.y)
                {
                    //Debug.Log("Traveling to A");
                    cameraRef.transform.position = Vector3.MoveTowards(cameraRef.transform.position, pointA.position, 0.1f);
                }
                atScene1 = true;
                atScene2 = false;
                startTransition = false;
            }
            else {
                //Debug.Log("Error: not at either scene position");
            }

        }
    }

    public void screenTransition() { 
        startTransition = true;
        Debug.Log("Started transition");
    }

}
