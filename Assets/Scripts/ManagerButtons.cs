using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerButtons : MonoBehaviour
{
   
  public void StartButton()
    {
      SceneManager.LoadScene("DesignTest");
    }

    
   public void AppQuit()
   {
     Application.Quit();
   }
}
