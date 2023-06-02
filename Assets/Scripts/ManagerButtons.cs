using System.Collections;
using System.Collections.Generic;
using HmsPlugin;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerButtons : MonoBehaviour
{

    public void Start()
    {
        HMSAdsKitManager.Instance.ShowBannerAd();
       // HMSAdsKitManager.Instance.ShowInterstitialAd();
    }

    public void StartButton()
    {
      SceneManager.LoadScene("DesignTest2");
    }

    public void Level2()
    {
      SceneManager.LoadScene("DesignTest");
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
