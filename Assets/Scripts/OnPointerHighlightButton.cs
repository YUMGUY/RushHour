using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class OnPointerHighlightButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textObj;
    public GameObject minigame;

    public void Start()
    {
        textObj.SetActive(false);
    }

    // When highlighted with mouse.
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Do something.
        if (!minigame.activeInHierarchy) {
            textObj.SetActive(true);
        }
        


        //Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
    }

    public void OnPointerExit(PointerEventData eventData) {
        textObj.SetActive(false);
    }

    
    // When selected.
    public void OnSelect(BaseEventData eventData)
    {
        // Do something.

        textObj.SetActive(false);
        //Debug.Log("<color=red>Event:</color> Completed selection.");
    }
}
