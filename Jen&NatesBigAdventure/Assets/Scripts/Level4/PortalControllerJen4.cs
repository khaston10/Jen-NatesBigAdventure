﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControllerJen4 : MonoBehaviour
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
            GameObject.Find("Canvas").GetComponent<Level4Main>().jenOnPortal = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerJen")
        {
            GameObject.Find("Canvas").GetComponent<Level4Main>().jenOnPortal = false;
        }
    }
}