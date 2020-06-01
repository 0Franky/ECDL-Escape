using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour {

    public CharacterController2D controller;
    public Rigidbody2D rb;
    public Animator anmtr;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool inCombat = false;
    bool jump = false;
    public Transform enemyPos;

    void Start () {
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Jump script
        if (Input.GetButtonDown("Jump") && !inCombat) {
            jump = true;
            // Animation plays only if player is grounded (otherwise it could play multiple times when in air)
            if (controller.isGrounded()) {
                anmtr.SetBool("jump", true);
            }
        }
        // Movement scripts
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

        // This is for moving close to the enemy

        //// Attack scripts
        //if (Input.GetButtonDown("Fire1") && noAttacking()) {
        //    anmtr.SetBool("attack01", true);
        //}

        //if (Input.GetButtonDown("Fire2") && noAttacking()) {
        //    anmtr.SetBool("attack02", true);
        //}
    }

    // FixedUpdate is used for physics
    void FixedUpdate() {
        // If not in combat, move normally
        if (!inCombat) {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
        // If in combat, automatically move close to the enemy you're fighting
        else {
            if (rb.position.x < enemyPos.position.x - 0.22) {
                controller.Move((runSpeed/2) * Time.fixedDeltaTime, false, false);
            }
            else if(rb.position.x > enemyPos.position.x - 0.18) {
                controller.Move((-runSpeed / 2) * Time.fixedDeltaTime, false, false);
            }
            if(rb.velocity.x == 0 && rb.transform.localScale.x == -1) {
                controller.Flip();
            }
        }
        
    }

    // Called when jump animation ends
    public void JumpEnded() {
        anmtr.SetBool("jump", false);
        Debug.Log("JumpEnded");
    }

    // Called when Light Attack animation ends
    public void Attack01Ended() {
        anmtr.SetBool("attack01", false);
        Debug.Log("Attack01Ended");
    }

    // Called when Heavy Attack animation ends
    public void Attack02Ended() {
        anmtr.SetBool("attack02", false);
        Debug.Log("Attack02Ended");
    }

    // Called when entering combat to go towards enemy
    public void GoToEnemy(Transform enemyPos) {
        
    }

    private bool noAttacking() {
        return !(anmtr.GetBool("attack01") || anmtr.GetBool("attack02"));
    }
}
