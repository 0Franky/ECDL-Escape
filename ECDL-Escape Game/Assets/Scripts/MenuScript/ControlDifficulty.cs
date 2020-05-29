using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDifficulty : MonoBehaviour
{
    private Text textshowed;
    // Start is called before the first frame update
    void Start()
    {
        textshowed = GetComponent<Text>();
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
