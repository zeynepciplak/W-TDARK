using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinToplama : MonoBehaviour
{

    private AudioSource coinSesi;

    private void Start()
    {
        coinSesi = GetComponent<AudioSource>();

    }
   private void OnTriggerEnter(Collider other)
   {
    if(other.gameObject.CompareTag("coin"))
    {
        Destroy(other.gameObject);
        coinSesi.Play();

    }
   }
}
