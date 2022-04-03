using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float shakeDuration = -1f;
    private float shakeMag = 0.5f;
    private float dampingSpeed = 1.0f;
    Vector3 underBarPos;

    public bool canExplode = true;

    private bool triggerExplode = false;

    private void OnEnable()
    {
        underBarPos = new Vector3 (transform.position.x, transform.position.y - 20, transform.position.z);
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
            transform.localPosition = underBarPos + Random.insideUnitSphere * shakeMag;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else if (triggerExplode){ 
            shakeDuration = -1f;
            transform.localPosition = underBarPos;
            triggerExplode = false;
        }
    }

    public void TriggerShake() {
        triggerExplode = true;
        shakeDuration = 0.7f;
    }
}
