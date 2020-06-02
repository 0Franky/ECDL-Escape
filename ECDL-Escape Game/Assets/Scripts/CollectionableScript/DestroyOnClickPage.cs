using Packages.Rider.Editor.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClickPage : MonoBehaviour
{

    public Text counter;
   
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Destroy(gameObject);
        counter.text = (Int16.Parse(counter.text) + 1).ToString();
    }
}
