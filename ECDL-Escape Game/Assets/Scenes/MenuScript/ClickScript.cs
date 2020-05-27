using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickScript : MonoBehaviour
{
    
    public void CLickOnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickExit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
   
}
