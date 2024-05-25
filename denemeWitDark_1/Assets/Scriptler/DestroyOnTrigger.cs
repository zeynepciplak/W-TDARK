using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
   
   public void OnTriggerEnter(Collider other)
   {

    Debug.Log("OnTriggerEnter called with: " + other.name);

    if(other.CompareTag("Player"))
    {
        Debug.Log("Player detected, destroying object.");
        Destroy(gameObject);
    }
   }
}
