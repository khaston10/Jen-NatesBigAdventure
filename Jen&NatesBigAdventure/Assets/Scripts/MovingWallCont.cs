using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallCont : MonoBehaviour
{
    public bool locked;
    public int rightEndPoint;
    public int leftEndPoint;
    public int speed;

    float currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = 0;
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        // When wall is unlocked move it right until it reached its endpoint.
        if (transform.position.x < rightEndPoint && locked == false)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        else if (transform.position.x > leftEndPoint && locked)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

    }
}
