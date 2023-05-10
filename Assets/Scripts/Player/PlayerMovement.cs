using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float sideSpeed = 10f;
    public bool isMoving = true;
    public float leftBound;
    public float rightBound;


    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

            //clamp player position on the x axis

            if (transform.position.x < leftBound)
            {
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            }
            if (transform.position.x > rightBound)
            {
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            }
        }
    }
}
