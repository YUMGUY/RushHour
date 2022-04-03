using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float shakeDuration = 0f;
    private float shakeMag = 0.5f;
    private float dampingSpeed = 1.0f;
    Vector3 initialPos;

    private void OnEnable()
    {
        initialPos = transform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPos + Random.insideUnitSphere * shakeMag;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else { 
            shakeDuration = 0f;
            transform.localPosition = initialPos;
        }
    }

    public void TriggerShake() {
        shakeDuration = 0.7f;
    }
}
