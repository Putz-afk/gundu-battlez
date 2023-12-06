using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore() {
        score += 100;
        scoreText.text = "Score: " + score;
    }
}
