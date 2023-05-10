using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            List<Transform> transformChildren = new List<Transform>();

            // Get the transform of all children belonging to the cube
            for (int i = 0; i < other.transform.childCount; i++)
            {
                transformChildren.Add(other.transform.GetChild(i));
            }

            for (int i = 0; i < transformChildren.Count; i++)
            {
                // Enable the BoxCollider and use gravity on the child game object
                Transform otherTransform = transformChildren[i];
                otherTransform.GetComponent<BoxCollider>().enabled = true;
                otherTransform.GetComponent<Rigidbody>().useGravity = true;

                GameObject childCube = Instantiate(otherTransform.gameObject, transform.position, Quaternion.identity, transform);
                childCube.transform.parent = transform;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                childCube.transform.position = new Vector3(transform.position.x, 1, transform.position.z);

            }

            Destroy(other.gameObject);
        }

        if (other.tag == "Obstacle")
        {
            transform.GetChild(1).parent = transform.parent;
            playerMovement.isMoving = false;
        }
    }
}
