using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimationControl : MonoBehaviour
{
    private Transform parentTrans;
    private static Animator animator;

    void Start()
    {
        parentTrans = transform.parent;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = parentTrans.position;
        transform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);

    }

    public static void WinAnimation()
    {
        animator.SetInteger("control", 1);
    }

    public static void LoseAnimation()
    {
        animator.SetInteger("control", 2);
    }
}
