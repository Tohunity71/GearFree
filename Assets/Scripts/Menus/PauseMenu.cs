using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauzeMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && ExitGoalLevel3.endScreenIsOn == false)
        {
            if (GameIsPaused)
            {
                BackToGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        pauzeMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToGame()
    {
        pauzeMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameIsPaused = false;
    }

    public void Controls()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QQUIT");
    }
}
