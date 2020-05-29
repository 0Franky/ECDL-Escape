using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anmtr;
    public int moveForce = 400;
    public int upwardForce = 40;

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("d")) {
            //rb.transform.position = 
            rb.transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(new Vector2(moveForce * Time.deltaTime, 0));
            anmtr.SetInteger("Run", 1);
            Debug.Log("Down D");
        }

        if (Input.GetKey("a")) {
            //rb.transform.position = 
            rb.transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(new Vector2(-moveForce * Time.deltaTime, 0));
            anmtr.SetInteger("Run", -1);
            Debug.Log("Down A");
        }

        if (Input.GetKeyDown("w")) {
            rb.AddForce(new Vector2(0, upwardForce * Time.deltaTime), ForceMode2D.Impulse);
        }

        //if (Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        //{
        //    anmtr.SetInteger("Run", 0);
        //    Debug.Log("Up D");
        //}

        if (rb.velocity.x <= 0.1 && rb.velocity.x >= -0.1) {
            anmtr.SetInteger("Run", 0);
            Debug.Log("Too little force");
        }
    }
}
