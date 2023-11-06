using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject crosshair;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //freezes time, activates pauseMenu and deactivates crosshair 
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    //changes scene to menu scene
    public void MainMenuButton()
    {
        Save();
        pauseMenuUI.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    //Resumes time, dactivates pauseMenu and activates crosshair 
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }
    
    public void Save()
    {
        //to be done later
    }

    //closes application
    public void QuitButton()
    {
        Save();
        Time.timeScale = 1f;
        Application.Quit();
    }


}
