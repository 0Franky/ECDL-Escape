using Packages.Rider.Editor.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClickPage : MonoBehaviour
{

    public Text counter;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(gameObject);
            counter.text = (Int16.Parse(counter.text) + 1).ToString();
            
        }
    }
}
