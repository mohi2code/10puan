using System.Collections;
using System.Collections.Generic;
using HmsPlugin;
using HuaweiMobileServices.Base;
using HuaweiMobileServices.Ads;
using HuaweiMobileServices.IAP;
using HuaweiMobileServices.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxController : MonoBehaviour
{

    public GameObject character;

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("PlayerChar");
    }

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
                Transform parentTransform = transform.parent;

                // Add the cube underneath the parent object
                GameObject childCube = Instantiate(otherTransform.gameObject, parentTransform.position, Quaternion.identity, parentTransform);
                childCube.transform.parent = transform;
                parentTransform.position = new Vector3(parentTransform.position.x, parentTransform.position.y + 1, parentTransform.position.z);
                childCube.transform.position = new Vector3(parentTransform.position.x, 1, parentTransform.position.z);

            }

            Destroy(other.gameObject);
        }

        if(other.tag == "Coin" && transform.parent.tag == "Player")
        {

            if(PlayerController.score == 1)
            {
                PurchaseProduct("coin100");
            }

            PlayerController.score += 1;
            character.transform.parent.gameObject.GetComponent<CoinCollect>().PlayCoinCollectSound();
            Destroy(other.gameObject);
        }

        if (other.tag == "Obstacle")
        {
            transform.parent = transform.parent.parent;
        }

        if (other.CompareTag("End"))
        {
            HMSAdsKitManager.Instance.ShowInterstitialAd();

            Debug.Log("Congrats");
            PlayerMovement.isMoving = false;


            if(PlayerController.score >= 2)
            {
                Debug.Log("you win");
                CharAnimationControl.WinAnimation();
                HMSAdsKitManager.Instance.OnRewarded = OnRewarded;
                HMSAdsKitManager.Instance.ShowRewardedAd();
            }
            else
            {
                Debug.Log("you lose");
                CharAnimationControl.LoseAnimation();
                HMSIAPManager.Instance.PurchaseProduct("coin100");
                PurchaseProduct("removeAds");
            }
        }
    }

    public void OnRewarded(Reward reward)
    {
        PlayerController.score += 10;
    }

    public void PurchaseProduct(string productID)
    {
        Debug.Log($"PurchaseProduct");

        HMSIAPManager.Instance.PurchaseProduct(productID);
    }

}
