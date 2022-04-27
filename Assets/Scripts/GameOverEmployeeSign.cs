using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverEmployeeSign : MonoBehaviour
{
    private int highScoreRank = 0;
    public GameObject employeeSign;
    private Sprite employeeSignSpr;
    public Sprite rank1;
    public Sprite rank2;
    public Sprite rank3;
    public Sprite rank0;
    public GameObject bloodyOverlay;
    public GameObject bloodyHead;

    // Start is called before the first frame update
    void Start()
    {
        bloodyOverlay.SetActive(true);
        employeeSign.SetActive(true);
        bloodyHead.SetActive(false);
        highScoreRank = PlayerPrefs.GetInt("highScore");
        //employeeSignSpr = employeeSign.GetComponent<Image>().sprite;

        if (highScoreRank <= 0)
        {
            bloodyOverlay.SetActive(false);
            employeeSign.SetActive(false);
            bloodyHead.SetActive(true);
        }
        else if (highScoreRank == 1)
        {
            employeeSign.GetComponent<Image>().sprite = rank1;
        }
        else if (highScoreRank == 2)
        {
            employeeSign.GetComponent<Image>().sprite = rank2;
        }
        else if (highScoreRank == 3)
        {
            employeeSign.GetComponent<Image>().sprite = rank3;
        }
        else {
            Debug.Log("Could not find high score");
        }

        //Debug.Log("Got to: " + highScoreRank);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
