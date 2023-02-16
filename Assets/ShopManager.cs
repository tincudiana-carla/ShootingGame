using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShopManager : ScoreChange
{
    public int[,] shopItems = new int[4,4];
    
    
    void Start()
    {
        myScoreText.text = "Score : " + ScoreNumber.ToString();
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        //price

        shopItems[2, 1] = 5;
        shopItems[2, 2] = 10;
        shopItems[2, 3] = 20;
        //quantity

        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;


    }
    
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (ScoreNumber >= shopItems[2, ButtonRef.GetComponent<ButtonScriptItem>().itemId])
        {

            ScoreNumber -= shopItems[2, ButtonRef.GetComponent<ButtonScriptItem>().itemId];
            shopItems[3, ButtonRef.GetComponent<ButtonScriptItem>().itemId]++;
            myScoreText.text = "Score : " + ScoreNumber.ToString();
            ButtonRef.GetComponent<ButtonScriptItem>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonScriptItem>().itemId].ToString();
        }
    }
    
}
