using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatCont : MonoBehaviour
{/* 
   The Bird will have 1 mode.
   1. Move left and right given endpoints.
   When a player collides with the bird an explosion animation will play and then the screen will change back to Home.
   */

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
    }

    // Update is called once per frame
    void Update()
    {
        // Set the correct animation.
        if (movingRight && anim.GetCurrentAnimatorStateInfo(0).IsName("WalkLeft"))
        {
            anim.Play("WalkRight");
        }

        else if (movingRight == false && anim.GetCurrentAnimatorStateInfo(0).IsName("WalkRight"))
        {
            anim.Play("WalkLeft");
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
