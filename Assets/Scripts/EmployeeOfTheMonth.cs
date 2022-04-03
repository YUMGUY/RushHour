using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeOfTheMonth : MonoBehaviour
{
    // Start is called before the first frame update

    private GameHandler gameManage;

    public Sprite[] spritesMonth;
    void Start()
    {
        gameManage = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManage.gameMode == 0)
        {

            this.GetComponent<Image>().sprite = spritesMonth[0];

        }

        else if (gameManage.gameMode == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = spritesMonth[1];
        }

        else if (gameManage.gameMode == 2)
        {

            this.GetComponent<SpriteRenderer>().sprite = spritesMonth[2];

        }
    }
}
