using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour {

    public CharacterController2D controller;
    public Rigidbody2D rb;
    public Animator anmtr;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;


    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            if (controller.isGrounded()) {
                anmtr.SetBool("jump", true);
            }
        }

 

        if (rb.velocity.x <= 0.1 && rb.velocity.x >= -0.1) {
            anmtr.SetInteger("run", 0);
            //Debug.Log("Too little force");
        }
        else if (rb.velocity.x > 0.1) {
            anmtr.SetInteger("run", 1);
        } 
        else if (rb.velocity.x < -0.1) {
            anmtr.SetInteger("run", -1);
        }

        if(!controller.isGrounded()) {
            anmtr.SetInteger("run", 0);
        }
    }

    // FixedUpdate is used for physics
    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }

    public void JumpEnded() {
        anmtr.SetBool("jump", false);
        Debug.Log("JumpEnded");
    }
}
