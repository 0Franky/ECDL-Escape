using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPage : MonoBehaviour
{
    private Button button;
    private string etichetta;


    private void Start()
    {
        button = GetComponent<Button>();
        etichetta = button.tag;
        button.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {

        GameObject page;
        switch (etichetta)
        {
            case "Page1":
                page= GameObject.FindGameObjectWithTag("DestructiblePage1");
                if(page == null)
                {
                    button.interactable = true;
                }
                
                break;
            case "Page2":
                page = GameObject.FindGameObjectWithTag("DestructiblePage2");
                if (page == null)
                {
                    button.interactable = true;
                }
                break;
            case "Page3":
                page = GameObject.FindGameObjectWithTag("DestructiblePage3");
                if (page == null)
                {
                    button.interactable = true;
                }
                break;
            case "Page4":
                page = GameObject.FindGameObjectWithTag("DestructiblePage4");
                if (page == null)
                {
                    button.interactable = true;
                }
                break;
            case "Page5":
                page = GameObject.FindGameObjectWithTag("DestructiblePage5");
                if (page == null)
                {
                    button.interactable = true;
                }
                break;
        }
    }
}
