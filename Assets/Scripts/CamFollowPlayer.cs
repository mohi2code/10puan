using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public float sSpeed = 10f;
    public Vector3 dist;
    public Transform lookTarget;
    private void LateUpdate()
    {
      Vector3 dPos = cameraTarget.position + dist;
      Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed *Time.deltaTime);
      transform.position = sPos;
      transform.LookAt(lookTarget.position);
    }

    /*public Transform target;
    private Vector3 offset;

    private void start()
    {
      offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
      Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
      transform.position = Vector3.Lerp(transform.position, newPos, 2 * Time.deltaTime);
    }*/

}
