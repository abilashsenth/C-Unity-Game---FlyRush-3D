using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class obstacleCollision : MonoBehaviour
{
    public TimeManager timeManager;
    public PlayScoreScript playScoreScript;
    public GameObject hb1, hb2, lifeheart1, lifeheart2, lifeheart3, playCanvas, gameOverCanvas, levelDoneCanvas;
    public Text levelDoneScoreText, gameOverScoreText, levelDoneHighScore, gameOverHighScore;
    public AudioSource audioSource;
    public AudioClip audioDataCoin, audioDataDiamond;
    private int lifeCount = 3;
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        hb1.SetActive(false);
        hb2.SetActive(false);
        gameOverCanvas.SetActive(false);
        levelDoneCanvas.SetActive(false);
        audioDataCoin = GetComponent<AudioClip>();
        audioDataDiamond = GetComponent<AudioClip>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "obstacle")
        {

            reduceLife();
            CinemachineShake.Instance.ShakeCamera(5f, 2f);
            timeManager.doSlowMotionCollision();
            hb1.SetActive(true);
            hb2.SetActive(true);
            if(!isGameOver)
            {
                StartCoroutine(disappearHearts());

            }
        }else if(other.gameObject.tag == "Finish")
        {
            openLevelComplete();
        }else if (other.gameObject.tag == "diamond")
        {
            audioSource.Play(0);
        }
        
    }

    private void reduceLife()
    {
        lifeCount--;
        switch (lifeCount)
        {
            case 2: lifeheart1.SetActive(false);
                break;
            case 1: lifeheart2.SetActive(false);
                break;
            case 0: lifeheart3.SetActive(false);
                break;
            case -1: openGameOver();
                isGameOver = true;
                timeManager.stopTime();
                Time.timeScale = 0f;

                break;
        }
    }

    private void openGameOver()
    {
        playCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        int levelScore = playScoreScript.returnScore();
        int highScore = playScoreScript.getLevelHighScore(SceneManager.GetActiveScene().buildIndex);
        gameOverHighScore.text = "highscore: " + highScore.ToString();
        gameOverScoreText.text = levelScore.ToString();
    }

    private void openLevelComplete()
    {
        timeManager.stopTime();
        Time.timeScale = 0f;
        playCanvas.SetActive(false);
        levelDoneCanvas.SetActive(true);
        int levelScore = playScoreScript.returnScore();
        int highScore = playScoreScript.getLevelHighScore(SceneManager.GetActiveScene().buildIndex);
        levelDoneHighScore.text = "highscore: " + highScore.ToString();
        levelDoneScoreText.text = levelScore.ToString();
    }

    public IEnumerator disappearHearts()
    {
        //waits for 1 second and executes the following
        yield return new WaitForSeconds(0.2f);
        hb1.SetActive(false);
        hb2.SetActive(false);
        timeManager.setTimeNormal();

    }

    public IEnumerator disappearHeartsStopTime()
    {
        //waits for 1 second and executes the following
        yield return new WaitForSeconds(0.2f);
        hb1.SetActive(false);
        hb2.SetActive(false);
        timeManager.stopTime();
    }

}
