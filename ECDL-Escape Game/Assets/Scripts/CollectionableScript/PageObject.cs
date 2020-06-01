﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu (fileName = "New Page", menuName = "CollectablePage")]
public class PageObject : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;
   
}
