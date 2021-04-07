using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteCanvas : MonoBehaviour
{

    public Button restartButton, mainMenuButton, nextLevelButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(restartSceneOnClick);
        mainMenuButton.onClick.AddListener(mainMenuOnClick);
        nextLevelButton.onClick.AddListener(nextSceneOnClick);
        int sceneID = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("FINISHEDLEVEL", sceneID);
    }

    public void mainMenuOnClick()
    {
        SceneManager.LoadScene(1);
    }
    public void restartSceneOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextSceneOnClick()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex)+1);
    }
}
