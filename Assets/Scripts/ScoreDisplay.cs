using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text playerWineText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Score: " + score.ToString();
        
        string playerWin = PlayerPrefs.GetString("PlayerWin", "player 1");
        playerWineText.text = "Winner player is : " + playerWin;

        if (SceneManager.GetActiveScene().name == "EndGame")
        {
            PlayerPrefs.DeleteKey("PlayerScore");
            
            
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Prototype 1")
        {
            int score = PlayerPrefs.GetInt("PlayerScore", 0);
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
