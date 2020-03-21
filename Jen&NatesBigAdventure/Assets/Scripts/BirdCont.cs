﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdCont : MonoBehaviour
{ /* 
   The Bird will have 1 mode.
   1. Move left and right given endpoints.
   When a player collides with the bird an explosion animation will play and then the screen will change back to Home.
   */

    public float rightEndPoint;
    public float leftEndPoint;
    public GameObject explosion;
    public BoxCollider2D collider2D;
    public float speed;

    Animator anim;
    GameObject t;
    bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        movingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the correct animation.
        if (movingRight && anim.GetCurrentAnimatorStateInfo(0).IsName("FlyLeft"))
        {
            anim.Play("FlyRight");
        }

        else if (movingRight == false && anim.GetCurrentAnimatorStateInfo(0).IsName("FlyRight"))
        {
            anim.Play("FlyLeft");
        }

        // Moves Groomsman right.
        if (movingRight)
        {
            if (transform.localPosition.x <= rightEndPoint)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }

            else movingRight = false;
        }

        // Moves Groomsman left.
        else
        {
            if (transform.localPosition.x >= leftEndPoint)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

            else movingRight = true;


        }

    }

    public void CreateExplosion()
    {
        t = Instantiate(explosion);
        t.transform.localPosition = transform.position;

    }

    IEnumerator WaitForAnimation()
    {
        //float length = anim.animation["TurnAround"].clip.length;
        yield return new WaitForSeconds(1.0f);

        // Return to Home Screen.
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Turn the collider off so that only one explosion plays.
            collider2D.enabled = false;

            // Play explosion animation
            CreateExplosion();

            // Wait the duration of the animation.
            StartCoroutine("WaitForAnimation");

        }
    }
}
