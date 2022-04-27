using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeOfTheMonth : MonoBehaviour
{
    // Start is called before the first frame update

    private GameHandler gameManage;
    private Image image;
    private Color tempColor;

    public Sprite[] spritesMonth;
    void Start()
    {
        gameManage = GameObject.Find("GameHandler").GetComponent<GameHandler>();

        image = this.GetComponent<Image>();
        tempColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManage.gameMode != 0) {
            tempColor.a = 1.0f;
            image.color = tempColor;
        }

        if (gameManage.gameMode == 0)
        {
            tempColor.a = 0.0f;
            image.color = tempColor;
        }
        else if (gameManage.gameMode == 1)
        {
            this.GetComponent<Image>().sprite = spritesMonth[0];
        }

        else if (gameManage.gameMode == 2)
        {

            this.GetComponent<Image>().sprite = spritesMonth[1];

        }
        else {
            this.GetComponent<Image>().sprite = spritesMonth[2];
        }
    }

    void initializeSprites()
    {
        Image[] photos = GameObject.Find("EmployeePhotos").GetComponentsInChildren<Image>();

        for(int i = 0; i < photos.Length; i++)
        {
            spritesMonth[i] = photos[i].sprite;
        }
    }
}
