using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerButtons : MonoBehaviour
{
   
    private void StartButton()
    {
        SceneManager.LoadScene("GameLevel");
    }

    
   private void AppQuit()
   {
     Application.Quit();
   }
}
