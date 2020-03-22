using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{
    public bool switchON;
    public int switchNumber;
    public int levelNumber;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        switchON = false;
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.5f, 0.5f, 0.5f, 1f); // Set to opaque gray
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerJen" || other.gameObject.tag == "Player")
        {
            switchON = true;
            renderer.color = Color.yellow;
            if(levelNumber == 2) GameObject.Find("Canvas").GetComponent<Level2Main>().ActivateWall(switchNumber);
            else if(levelNumber == 3) GameObject.Find("Canvas").GetComponent<Level3Main>().ActivateWall(switchNumber);
            else if (levelNumber == 4) GameObject.Find("Canvas").GetComponent<Level4Main>().ActivateWall(switchNumber);
            else if (levelNumber == 5) GameObject.Find("Canvas").GetComponent<Level5Main>().ActivateWall(switchNumber);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerJen" || other.gameObject.tag == "Player")
        {
            switchON = false;
            renderer.color = new Color(0.5f, 0.5f, 0.5f, 1f); // Set to opaque gray
            if (levelNumber == 2) GameObject.Find("Canvas").GetComponent<Level2Main>().DeActiveWall(switchNumber);
            else if(levelNumber == 3) GameObject.Find("Canvas").GetComponent<Level3Main>().DeActiveWall(switchNumber);
            else if (levelNumber == 4) GameObject.Find("Canvas").GetComponent<Level4Main>().DeActiveWall(switchNumber);
            else if (levelNumber == 5) GameObject.Find("Canvas").GetComponent<Level5Main>().DeActiveWall(switchNumber);

        }
    }
}
