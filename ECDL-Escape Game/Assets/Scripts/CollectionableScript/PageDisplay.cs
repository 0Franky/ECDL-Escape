using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageDisplay : MonoBehaviour
{
    public PageObject page;
    public Text titleText;
    public Text descriptionText;

    public Image artworkImage;
    void Start()
    {
        titleText.text = page.name;
        descriptionText.text = page.description;
        artworkImage.sprite = page.artwork;
    }

  
}
