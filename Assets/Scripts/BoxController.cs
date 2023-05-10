using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box" && transform.parent.tag == "Player")
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

                // Determine if the parent object is tagged as "Player"
                Transform parentTransform = transform.tag == "Player" ? transform : transform.parent;

                // Add the cube underneath the parent object
                GameObject childCube = Instantiate(otherTransform.gameObject, parentTransform.position, Quaternion.identity, parentTransform);
                parentTransform.position = new Vector3(parentTransform.position.x, parentTransform.position.y + 1, parentTransform.position.z);
                childCube.transform.position = new Vector3(transform.position.x, 1, transform.position.z);

            }

            Destroy(other.gameObject);
        }

        if (other.tag == "Obstacle")
        {
            transform.parent = transform.parent.parent;
        }
    }
}
