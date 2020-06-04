using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class LostLife : MonoBehaviour
{

    private static readonly string Difficolta = "Difficolta";
    private static readonly int NUMERO_VITE_FACILE = 3;
    private static readonly int NUMERO_VITE_MEDIA = 2;
    private static readonly int NUMERO_VITE_DIFFICILE = 1;

    public LevelControlScript levelControl;
    
    private int numberLife;
    public GameObject[] Life;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Life.Length.ToString());
        SettaVite();
       

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if(numberLife > 1)
            {
                setAnimationLostLife(numberLife - 1);
                numberLife--;
            }
            else
            {
                setAnimationLostLife(numberLife - 1);
                Debug.Log("HAI PERSO");
                levelControl.youLose();
                //SceneManager.LoadScene(0);
            }
       
        }
    }

    private void SettaVite()
    {

        switch (PlayerPrefs.GetString(Difficolta))
        {
            case "FACILE":
                numberLife = NUMERO_VITE_FACILE;
                activeLife(numberLife);
                break;
            case "MEDIA":
                numberLife = NUMERO_VITE_MEDIA;
                activeLife(numberLife);
                break;
            case "DIFFICILE":
                numberLife = NUMERO_VITE_DIFFICILE;
                activeLife(numberLife);
                break;
        }
    }

   private void activeLife(int nLife)
    {
        if (numberLife <= Life.Length)
        {
            Debug.Log("SONO IF QUI");
            for (int i = 0; i < Life.Length; i++)
            {
                if (i > numberLife-1)
                {
                    Life[i].SetActive(false);
                    Debug.Log("SONO QUI");
                }
                else
                {
                    Life[i].SetActive(true);
                }
            }
        }
    }

    private void setAnimationLostLife(int i)
    {
            Animator anim = Life[i].GetComponent<Animator>();
            anim.SetBool("lost", true);
    }


}
