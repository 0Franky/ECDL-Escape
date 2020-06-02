using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public GameObject inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        if (inventory.activeInHierarchy)
        {
            inventory.SetActive(false);
        }
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Esci()
    {
        SceneManager.LoadScene(0);
    }

}
