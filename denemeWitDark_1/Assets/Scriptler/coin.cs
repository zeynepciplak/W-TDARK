using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class coin : MonoBehaviour
{
    
    

        private bool _collected = false;

    //private AudioManager audioManager;

    private Transform playerTransform; // Store Player's Transform component

    void Start()
    {
        
       // audioManager = AudioManager.instance;
        // Find the GameObject with "Player" tag (assuming it has a Transform component)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Player")) // Check if colliding with "Player" tag
        {
            ScoreText.coinAmount += 1;
            Destroy(gameObject);
        }
        */
        if (collision.gameObject.CompareTag("Player") )
        {
            if (!_collected)
            {
           /*      // coinAS sesini AudioManager üzerinden çal
            if (audioManager != null && audioManager.coinAS != null)
            {
                audioManager.PlayAudio(audioManager.coinAS);
            }*/
                ScoreText.coinAmount += 1;
                _collected = true;// Not needed if destroying the game object
                Destroy(this.gameObject);// Only use if you intend to destroy the game object
                AudioManager.instance.PlayOneShot(FMODEvents.instance.coinCollected, this.playerTransform.position);

            }
        }
        if (collision.gameObject.CompareTag("PlayerLight"))
        {
            Debug.Log("Item");




            float distance = Vector3.Distance(transform.position, playerTransform.position);
            // Debug.Log("Distance to Player: " + distance + " units");

            if (distance > 8)
            {
                Debug.Log("20 metre");
            }
            else if (distance > 7.6f && distance <= 8)
            {
                Debug.Log("19 metre");
            }
            else if (distance > 7.2f && distance <= 7.6)
            {
                Debug.Log("18 metre");
            }
            else if (distance > 6.8f && distance <= 7.2)
            {
                Debug.Log("17 metre");
            }
            else if (distance > 6.4f && distance <= 6.8)
            {
                Debug.Log("16 metre");
            }
            else if (distance > 6f && distance <= 6.4)
            {
                Debug.Log("15 metre");
            }
            else if (distance > 5.6f && distance <= 6)
            {
                Debug.Log("14 metre");
            }
            else if (distance > 5.2f && distance <= 5.6)
            {
                Debug.Log("13 metre");
            }
            else if (distance > 4.8f && distance <= 5.2)
            {
                Debug.Log("12 metre");
            }
            else if (distance > 4.4f && distance <= 4.8)
            {
                Debug.Log("11  metre");
            }
            else if (distance > 4f && distance <= 4.4)
            {
                Debug.Log("10  metre");
            }
            else if (distance > 3.6f && distance <= 4)
            {
                Debug.Log("9 metre");
            }
            else if (distance > 3.2f && distance <= 3.6)
            {
                Debug.Log("8 metre");
            }
            else if (distance > 2.8f && distance <= 3.2)
            {
                Debug.Log("7 metre");
            }
            else if (distance > 2.4f && distance <= 2.8)
            {
                Debug.Log("6 metre");
            }
            else if (distance > 2f && distance <= 2.4)
            {
                Debug.Log("5 metre");
            }
            else if (distance > 1.6f && distance <= 2)
            {
                Debug.Log("4 metre");
            }
            else if (distance > 1.2f && distance <= 1.6)
            {
                Debug.Log("3 metre");
            }
            else if (distance > 0.8f && distance <= 1.2)
            {
                Debug.Log("2 metre");
            }
            else if (distance > 0.4f && distance <= 0.8)
            {
                Debug.Log("1 metre");
            }
            else
            {
                Debug.Log("Distance to Player: " + distance + " units"); // Yazd�rma format� de�i�meden devam
            }


        }

    }
    
}
