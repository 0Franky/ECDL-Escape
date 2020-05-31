using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAnimExplode : MonoBehaviour
{

    private Animator animator;
    private GameObject life;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        life = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life.activeSelf)
        {

        }
    }
}
