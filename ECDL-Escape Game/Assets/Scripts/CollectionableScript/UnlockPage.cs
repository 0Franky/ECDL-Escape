using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPage : MonoBehaviour
{
    private Button button;


    private void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {

        GameObject page = GameObject.FindGameObjectWithTag("Page1");
        if (page == null)
        {
            button.interactable = true;
        }
    }
}
