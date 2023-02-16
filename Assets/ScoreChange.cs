using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChange : MonoBehaviour
{
    public Text myScoreText;
    public int ScoreNumber;
    void Start()
    {
        ScoreNumber = 0;
        myScoreText.text =  ScoreNumber.ToString();
    }

    public void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.tag == "Coin")
        {
            ScoreNumber++;
            Destroy(coin.gameObject);
            myScoreText.text = "Score : " + ScoreNumber;

        }
    }
}
