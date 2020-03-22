using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BridesmaidCont : MonoBehaviour
{
    /* 
   The BridesMaid will have 2 different modes.
   1. Move left and right given endpoints.
   2 Idle in one spot. 
   Regardless of the mode, when a player collides with the groomsman an explosion animation will play.
   */

    public bool idle; // 0: Moves left and right. 1: Idle
    public float rightEndPoint;
    public float leftEndPoint;
    public GameObject explosion;
    public BoxCollider2D collider2D;
    public float speed;
    public int level;
    public AudioSource explode;

    Animator anim;
    GameObject t;
    bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        movingRight = true;

        if (idle == false) anim.Play("BrideWalkRight");
    }

    // Update is called once per frame
    void Update()
    {
        // This code deals with mode == 1 Idle
        if (idle)
        {

        }

        // This code deals with mode == 0 Left/Right
        else
        {
            // Set the correct animation.
            if (movingRight && anim.GetCurrentAnimatorStateInfo(0).IsName("BrideWalkLeft"))
            {
                anim.Play("BrideWalkRight");
            }

            else if (movingRight == false && anim.GetCurrentAnimatorStateInfo(0).IsName("BrideWalkRight"))
            {
                anim.Play("BrideWalkLeft");
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

    }

    public void CreateExplosion()
    {
        explode.Play();
        t = Instantiate(explosion);
        t.transform.localPosition = transform.position;

    }

    IEnumerator WaitForAnimation()
    {
        //float length = anim.animation["TurnAround"].clip.length;
        yield return new WaitForSeconds(1.0f);

        // Return to Home Screen.
        SceneManager.LoadScene(sceneBuildIndex: level);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerJen")
        {
            // Turn the collider off so that only one explosion plays.
            collider2D.enabled = false;

            // Play explosion animation
            CreateExplosion();

            // Destory Player
            Destroy(collision.gameObject);

            // Wait the duration of the animation.
            StartCoroutine("WaitForAnimation");

        }
    }
}
