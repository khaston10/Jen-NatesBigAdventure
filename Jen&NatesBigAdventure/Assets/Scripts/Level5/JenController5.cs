using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JenController5 : MonoBehaviour
{
    #region Variables
    Rigidbody2D rigidbody2d;
    Animator anim;

    public bool movingLeft;
    public bool movingRight;
    public bool isJumping;
    public float speed;
    public float jumpSpeed;
    public float timeBetweenJumps;
    public bool hasLanded;
    public AudioSource jump;

    float jumpCounter;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        jumpCounter = timeBetweenJumps;
    }

    // Update is called once per frame
    void Update()
    {
        //Update Jump Count.
        jumpCounter += Time.deltaTime;

        // Get user input.
        if (Input.GetKeyDown(KeyCode.A) && movingLeft == false)
        {
            movingLeft = true;
        }
        else if (Input.GetKeyUp(KeyCode.A) && movingLeft == true)
        {
            movingLeft = false;
            anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.D) && movingRight == false)
        {
            movingRight = true;
        }
        else if (Input.GetKeyUp(KeyCode.D) && movingRight == true)
        {
            movingRight = false;
            anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.W) && isJumping == false && jumpCounter > timeBetweenJumps && hasLanded)
        {
            isJumping = true;
            jumpCounter = 0;
        }

        // Move player.
        if (movingLeft)
        {
            anim.Play("Run");
            rigidbody2d.velocity = new Vector2(speed * -1, rigidbody2d.velocity.y);
        }

        else if (movingRight)
        {
            anim.Play("Run");
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
        }

        if (isJumping)
        {
            jump.Play();
            anim.Play("Jump");
            rigidbody2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = false;
            hasLanded = false;
        }
    }

    // Handles collisions.
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "JenObject")
        {
            Destroy(col.gameObject);
            GameObject.Find("Canvas").GetComponent<Level5Main>().itemsClaimedJen += 1;
        }

        if (col.gameObject.tag == "PlatformHard" || col.gameObject.tag == "PlatformSoft")
        {
            hasLanded = true;
        }

    }
}
