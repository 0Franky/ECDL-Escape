using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouLoseScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log("Hai Perso");
        LevelControlScript.instance.youLose();
    }

}
