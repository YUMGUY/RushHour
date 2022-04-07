using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAlert : MonoBehaviour
{
    public GameObject AlertFlash;
    private TMPro.TextMeshProUGUI alertTxt;
    //public GameObject mainCanvas;
    //private Transform alertParent;
    public GameObject alertParent;

    // Start is called before the first frame update
    void Start()
    {
        alertTxt = AlertFlash.GetComponent<TMPro.TextMeshProUGUI>();
        //alertParent = mainCanvas.transform.FindChild("Alert");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAlert(string messageTxt, int x_offset, int y_offset) {
        StartCoroutine(Alert(messageTxt, x_offset, y_offset));
    }

    IEnumerator Alert(string messageTxt, int x_offset, int y_offset)
    {
        Debug.Log(messageTxt);
        alertTxt.text = messageTxt;
        //Instantiate(AlertFlash, mainCanvas); 
        GameObject flash = Instantiate(AlertFlash, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        //flash.transform.parent = mainCanvas;
        flash.transform.SetParent(alertParent.transform, false);
        alertParent.transform.localPosition = new Vector3(x_offset, y_offset, 0);
        //flash.transform.localPosition += new Vector3(0,200,0);
        //Debug.Log(flash.transform.localPosition.x);
        Debug.Log(flash.transform.localPosition.y);
        yield return new WaitForSeconds(1);
        Destroy(flash);
        yield break;
    }
}
