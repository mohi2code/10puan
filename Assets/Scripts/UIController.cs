using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text text;

    void Start()
    {
        text.text = "Score: " + PlayerController.score;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + PlayerController.score;
    }
}
