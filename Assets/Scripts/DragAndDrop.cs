using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging;
    public GameObject Ingredient;
    private Vector2 screenPosition;
    private Vector2 worldPosition;
    private GameObject ingredInstance;
    private Rigidbody2D ingredRb;

    // Start is called before the first frame update
    void Start()
    {
        screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    }

    public void OnMouseDown()
    {
        //Instantiate the ingredient from that object
        ingredInstance = Instantiate(Ingredient, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        ingredRb = ingredInstance.GetComponent<Rigidbody2D>();
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        //If released, bounce up and freefall (with some rotation for fun)
        ingredRb.AddForce(new Vector2(0, 300));
        //ingredRb.AddTorque(400);
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        //Debug.Log("Mouse world pos: " + worldPosition.x);

        if (isDragging)
        {
            /*if (ingredRb != null) {
                Debug.Log("rb is assigned");
            }*/
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - ingredInstance.transform.position;

            ingredInstance.transform.Translate(mousePosition);
        }
        /* If player is on the outside bar screen
        if ( ) {
            Debug.Log("Changed Scenes while holding obj");
            isDragging = false;

        }*/
    }

}
