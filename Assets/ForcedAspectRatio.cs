using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedAspectRatio : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {
        float targetAspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowaspect / targetAspect;
        Camera camera = GetComponent<Camera>();

        if(scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        } else
        {
            float scalewidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scalewidth;
            rect.height = 1/0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
