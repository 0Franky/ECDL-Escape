using UnityEngine;
using UnityEngine.UI;

public class ControlDifficulty : MonoBehaviour
{

    private static readonly string FirstPlay = "FirstPlay2";
    private static readonly string Difficolta = "Difficolta";
    private int firstPlayInt;
    private Text textshowed;
    // Start is called before the first frame update
    void Start() {

        //PlayerPrefs.DeleteAll();
        textshowed = GetComponent<Text>();
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            textshowed.text = "FACILE";
            PlayerPrefs.SetString(Difficolta, textshowed.text);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            textshowed.text = PlayerPrefs.GetString(Difficolta);
        }
   
    }

    public void SaveDifficultySettings()
    {
        PlayerPrefs.SetString(Difficolta, textshowed.text);

    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveDifficultySettings();
        }
    }


    public void ChangeDifficultyFarward()
    {

        Debug.Log("SF");
        switch (textshowed.text.ToString())
        {
            case "FACILE":
                textshowed.text = "MEDIA";
                break;

            case "MEDIA":
                textshowed.text = "DIFFICILE";
                break;

            case "DIFFICILE":
                textshowed.text = "FACILE";
                break;
        }
    }

    public void ChangeDifficultyBack()
    {

        Debug.Log("SB");

        switch (textshowed.text.ToString())
        {
            case "FACILE":
                textshowed.text = "DIFFICILE";
                break;

            case "MEDIA":
                textshowed.text = "FACILE";
                break;

            case "DIFFICILE":
                textshowed.text = "MEDIA";
                break;
        }
    }
}
