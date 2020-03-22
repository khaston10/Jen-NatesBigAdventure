using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool elevatorOn;
    public float endpointUp;
    public float endPointDown;
    public float speed;

    bool movingUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (elevatorOn && movingUp)
        {
            if (transform.localPosition.y < endpointUp)
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }

            else movingUp = false;
        }

        else
        {
            if (transform.localPosition.y > endPointDown)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }

            else movingUp = true;
        }

    }
}
