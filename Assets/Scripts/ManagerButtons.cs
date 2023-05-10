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

    public void Level2()
    {
      SceneManager.LoadScene("DesignTest2");
    }

    
   public void AppQuit()
   {
     Application.Quit();
   }

   public void RestartScene()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
