using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class buttonOnclick : MonoBehaviour
{
    public Button playButton;
    public Button instaButton, ratingButton;
    public GameObject instaButtonObject, ratingButtonObject, title, playButtonGameobject, airplane;
    public Animator anim;
    public float waitTimeSeconds = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        playButton.onClick.AddListener(TaskOnClick);
        instaButton.onClick.AddListener(InstaOnClick);
        ratingButton.onClick.AddListener(RatingOnClick);
    }

    private void InstaOnClick()
    {
        Application.OpenURL("https://www.instagram.com/thenextbiggeek/");
    }

    private void RatingOnClick()
    {
        Debug.Log("review button shall be added finally");
    }

    public void TaskOnClick()
    {
        
        instaButtonObject.SetActive(false);
        ratingButtonObject.SetActive(false);
        airplane.SetActive(false);
        title.SetActive(false);
        playButtonGameobject.GetComponent<Renderer>().enabled = false; title.SetActive(false);
        anim.SetBool("isPlayEnabled", true);
        StartCoroutine(Wait_for_intro());

    }

    IEnumerator Wait_for_intro()
    {
        yield return new WaitForSeconds(waitTimeSeconds);
        if(PlayerPrefs.GetInt("FIRSTTIMEOPENING",1) == 1)
        {
            Debug.Log("FirstTimeOpening");
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
            SceneManager.LoadScene(2);

        }
        else
        {
            Debug.Log("Not the first time opening");
            if (PlayerPrefs.HasKey("FINISHEDLEVEL"))
            {
                int lastPlayedLevelIndex = PlayerPrefs.GetInt("FINISHEDLEVEL");
                SceneManager.LoadScene(lastPlayedLevelIndex+1);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
