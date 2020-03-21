using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControllerJen2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerJen")
        {
            GameObject.Find("Canvas").GetComponent<Level2Main>().jenOnPortal = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerJen")
        {
            GameObject.Find("Canvas").GetComponent<Level2Main>().jenOnPortal = false;
        }
    }
}