using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform cameraTarget;
    public float sSpeed = 10f;
    private Vector3 dist;


    private void Awake()
    {
        dist = transform.position;
    }

    private void LateUpdate()
    {
      Vector3 dPos = cameraTarget.position + dist;
      Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed *Time.deltaTime);
      transform.position = sPos;
      transform.LookAt(cameraTarget);
    }

}
