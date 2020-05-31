using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LostLife : MonoBehaviour
{

    private static readonly string Difficolta = "Difficolta";
    private int numberLife;
    public GameObject[] Life;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Life.Length.ToString());
        SettaVite();
       

    }

    private void SettaVite()
    {

        switch (PlayerPrefs.GetString(Difficolta))
        {
            case "FACILE":
                numberLife = 3;
                break;
            case "MEDIA":
                numberLife = 2;
                Life[2].SetActive(false);
                break;
            case "DIFFICILE":
                numberLife = 1;
                Life[1].SetActive(false);
                Life[2].SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)){
           
        }
    }
}
