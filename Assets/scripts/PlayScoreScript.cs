using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScoreScript : MonoBehaviour
{
    public Text scoreText;
    int score, highScore, levelIndex;
    
    void Start()
    {
        scoreText = GetComponent<Text>();
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        highScore = 0;
        score = 0;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void coinCollision()
    {
        score = score + 10;
        scoreText.text = score.ToString();
    }

    public void diamondCollision()
    {
        score = score + 100;
        scoreText.text = score.ToString();
    }

    public int returnScore()
    {
        return score;
    }

    public int getLevelHighScore(int levelIndex)
    {
        string highScoreKey = levelIndex.ToString() + score;
        if (PlayerPrefs.HasKey(highScoreKey))
        {
            return PlayerPrefs.GetInt(highScoreKey);
        }
        else
        {
            PlayerPrefs.SetInt(highScoreKey, returnScore());
            return returnScore();
        }

    }

    

}
