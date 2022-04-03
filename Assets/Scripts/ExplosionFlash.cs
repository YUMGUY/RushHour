using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ExplosionFlash : MonoBehaviour
{
    Image _image = null;
    Coroutine _currentFlashRoutine = null;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForOneFlash, Color newColor) { 
        _image.color = newColor;



        if (_currentFlashRoutine != null) {
            StopCoroutine(_currentFlashRoutine);
        }
        _currentFlashRoutine = StartCoroutine(Flash(secondsForOneFlash));
    }

    IEnumerator Flash(float secondsForOneFlash) {
        float flashInDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashInDuration; t += Time.deltaTime) { 
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(0, 1, t / flashInDuration);
            _image.color = colorThisFrame;

            yield return null;
        }
        float flashOutDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(1, 0, t / flashOutDuration);
            _image.color = colorThisFrame;

            yield return null;
        }

        _image.color = new Color(0, 0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
