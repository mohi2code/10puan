using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _runningSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
