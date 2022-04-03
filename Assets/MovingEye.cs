using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingEye : MonoBehaviour
{
    // Start is called before the first frame update
    public Image eye;
    public Rigidbody2D eyeRB;
    public CircleCollider2D circleCollider;
    public MovingEye canary;

    Vector3 prevMouse;
    float totalSoFar;
    public bool inside;
    void Start()
    {
        totalSoFar = 0;
        inside = true;
        eyeRB.transform.position = eye.transform.position;
        circleCollider = this.GetComponent<CircleCollider2D>();
        circleCollider.radius = 151 * (Screen.currentResolution.width / Screen.currentResolution.height);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition != prevMouse)
        {
            totalSoFar = Time.deltaTime;
        } else
        {
            totalSoFar += Time.deltaTime;
        }

        Vector3 newPos = Input.mousePosition;
        if (inside)
        {
            eyeRB.MovePosition(eyeRB.transform.position + (newPos - eyeRB.transform.position).normalized * 2f);
            eye.gameObject.transform.position = eyeRB.transform.position;

            if(canary != null)
            {
                canary.transform.position = eyeRB.transform.position;
            } 
        } else
        {
            if (canary != null)
            {
                canary.gameObject.GetComponent<Rigidbody2D>().MovePosition(eyeRB.transform.position + (newPos - eyeRB.transform.position).normalized * 1.5f);
                if (canary.inside == true)
                {
                    eyeRB.MovePosition(eyeRB.transform.position + (newPos - eyeRB.transform.position).normalized * 1.5f);
                    eye.gameObject.transform.position = eyeRB.transform.position;
                }
                canary.transform.position = eyeRB.transform.position;
            }
        }

        prevMouse = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Eye")
        {
            inside = false;
            Debug.Log("Collided!");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = true;
    }
}
