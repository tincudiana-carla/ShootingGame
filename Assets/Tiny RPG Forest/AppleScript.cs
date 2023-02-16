using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AppleScript : MonoBehaviour
{
    public Text myScoreText;
    private int ScoreNumber;
    void Start()
    {
        ScoreNumber = 0;
        myScoreText.text = ScoreNumber.ToString();
    }

    private void OnTriggerEnter2D(Collider2D apple)
    {
        if (apple.tag == "Apple")
        {
            ScoreNumber++;
            Destroy(apple.gameObject);
            myScoreText.text = ScoreNumber.ToString();
        }
    }
}
