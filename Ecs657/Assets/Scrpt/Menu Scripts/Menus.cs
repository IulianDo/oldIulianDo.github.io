using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    bool gameIsPaused = false;
    bool gameIsOver = false;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public GameObject crosshair;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsOver)
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

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MainMenuButton()
    {
        Save();
        pauseMenuUI.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {  
        Cursor.lockState = CursorLockMode.Locked;
        gameOverUI.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1f;
        gameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {  
        Cursor.lockState = CursorLockMode.None;
        crosshair.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsOver = true;
    }

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

    }

    public void QuitButton()
    {
        Save();
        Time.timeScale = 1f;
        Application.Quit();
    }


}