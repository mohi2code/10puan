using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInitializer : MonoBehaviour
{
    [SerializeField] int count = 0;
    [SerializeField] GameObject objectPrefab;

    private void OnEnable()
    {
        for (int i = 0; i < count; i++)
        {
            var newTransform = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
            Instantiate(objectPrefab, newTransform, Quaternion.identity, transform);
        }
    }
}
