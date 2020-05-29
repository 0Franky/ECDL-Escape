using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public Text textshowed;
    public void ClickOnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickExit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
   
    
}
