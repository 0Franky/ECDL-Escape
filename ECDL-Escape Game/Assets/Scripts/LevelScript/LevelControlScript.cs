using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour
{

    public static LevelControlScript instance = null;
    GameObject levelSign, gameOverObject, youWinObject;
    int sceneIndex, levelPassed;
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Time.timeScale = 1f;
        levelSign = GameObject.Find("LevelNumber");
        gameOverObject = GameObject.Find("GameOver");
        youWinObject = GameObject.Find("YouWin");

        gameOverObject.gameObject.SetActive(false);
        youWinObject.gameObject.SetActive(false);
        pauseMenuUI.gameObject.SetActive(false);
        levelSign.gameObject.SetActive(true);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    void Update()
    {
        if(!(gameOverObject.gameObject.activeInHierarchy || youWinObject.gameObject.activeInHierarchy))
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
        

    }



    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameObject[] page = GameObject.FindGameObjectsWithTag("Page");
        if (inventory.activeInHierarchy)
        {
            inventory.SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                page[i].SetActive(false);
            }



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


    public void youWin()
    {
        if (sceneIndex == 3)
            Invoke("loadMainMenu", 1f);
        else
        {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);

            levelSign.gameObject.SetActive(false);
            youWinObject.gameObject.SetActive(true);
            Invoke("loadNextLevel", 1f);

        }

    }

    public void youLose()
    {
        levelSign.SetActive(false);
        gameOverObject.gameObject.SetActive(true);
        Debug.Log("Sexy Lose");
        Time.timeScale = 0f;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    
    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void loadThisLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }


}

