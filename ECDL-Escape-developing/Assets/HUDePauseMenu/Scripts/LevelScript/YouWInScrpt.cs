using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWInScrpt : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        if (collider2D.CompareTag("Player"))
        {
            Debug.Log("Hai Vinto");
            LevelControlScript.instance.youWin();
        }
        
    }

    
}
