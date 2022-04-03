using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop_Alt : MonoBehaviour
{
    private bool isDragging;
    private Vector3 homePosition;

    // Start is called before the first frame update
    void Start()
    {
        homePosition = transform.position;
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        transform.position = homePosition;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
            
        }
    }

    public void returnHome() {
        isDragging = false;
        transform.position = homePosition;
    }
}
