using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{

    public Button restartButton, mainMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(restartSceneOnClick);
        mainMenuButton.onClick.AddListener(mainMenuOnClick);
    }

    public void mainMenuOnClick()
    {
        SceneManager.LoadScene(1);
    }
    public void restartSceneOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
