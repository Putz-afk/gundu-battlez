using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutDetector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //private bool isOut = false;
    public int score = 0;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.tag == "targetMarble")
    //    {
    //        isOut = true;
    //        Score++;
    //        Debug.Log("Score!");
    //    }
    //}

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }
}
