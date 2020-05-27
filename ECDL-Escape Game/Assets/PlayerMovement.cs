using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anmtr;

    private int forceMov = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            //rb.transform.position = 
            rb.transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(new Vector2(forceMov, 0));
            anmtr.SetInteger("Run", 1);
            Debug.Log("Down D");
        }

        if (Input.GetKey("a"))
        {
            //rb.transform.position = 
            rb.transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(new Vector2(-forceMov, 0));
            anmtr.SetInteger("Run", -1);
            Debug.Log("Down A");
        }

        if (Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
            anmtr.SetInteger("Run", 0);
            Debug.Log("Up D");
        }

    }
}
