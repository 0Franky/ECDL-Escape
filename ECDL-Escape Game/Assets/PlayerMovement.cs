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

    private float dirX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        if (dirX > 0 || dirX < 0)
        {
            rb.transform.localScale = new Vector3(RoundItUp(dirX), 1, 1);
            rb.AddForce(new Vector2(moveForce * dirX * Time.deltaTime, 0));
            anmtr.SetInteger("run", RoundItUp(dirX));
        }

        if (Input.GetButtonDown("Jump") && !anmtr.GetBool("jump"))
        {
            anmtr.SetBool("jump", true);
            rb.AddForce(new Vector2(0, upwardForce * Time.deltaTime), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1") && noAttacking())
        {
            anmtr.SetBool("attack01", true);
        }

        if (Input.GetButtonDown("Fire2") && noAttacking())
        {
            anmtr.SetBool("attack02", true);
        }

        //Debug.Log("rb.velocity.x");
        //Debug.Log(rb.velocity.x);
        //Debug.Log("run");
        //Debug.Log(anmtr.GetInteger("run"));
        if (rb.velocity.x <= 0.1 && rb.velocity.x >= -0.1) {
            anmtr.SetInteger("run", 0);
            //Debug.Log("Too little force");
        }
    }

    private int RoundItUp(float f)
    {
        if (f > 0)
        {
            return 1;
        }
        else if (f < 0)
        {
            return -1;
        }
        return 0;
    }

    public void JumpEnded()
    {
        anmtr.SetBool("jump", false);
        Debug.Log("JumpEnded");
    }

    public void Attack01Ended()
    {
        anmtr.SetBool("attack01", false);
        Debug.Log("Attack01Ended");
    }

    public void Attack02Ended()
    {
        anmtr.SetBool("attack02", false);
        Debug.Log("Attack02Ended");
    }

    private bool noAttacking()
    {
        return !(anmtr.GetBool("attack01") || anmtr.GetBool("attack02"));
    }
}
