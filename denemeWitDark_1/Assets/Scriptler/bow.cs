using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    private bool _collected = false;
    private Transform playerTransform; // Store Player's Transform component

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!_collected)
            {

                bowText.bowAmount += 1;
                _collected = true;// Not needed if destroying the game object
                Destroy(this.gameObject);// Only use if you intend to destroy the game object
            }
        }
        if (collision.gameObject.CompareTag("PlayerLight"))
        {

            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (distance > 8)
            {
                Debug.Log("Yay, " + "20 metre");
            }
            else if (distance > 7.6f && distance <= 8)
            {
                Debug.Log("Yay, " + "19 metre");
            }
            else if (distance > 7.2f && distance <= 7.6)
            {
                Debug.Log("Yay, " + "18 metre");
            }
            else if (distance > 6.8f && distance <= 7.2)
            {
                Debug.Log("Yay, " + "17 metre");
            }
            else if (distance > 6.4f && distance <= 6.8)
            {
                Debug.Log("Yay, " + "16 metre");
            }
            else if (distance > 6f && distance <= 6.4)
            {
                Debug.Log("Yay, " + "15 metre");
            }
            else if (distance > 5.6f && distance <= 6)
            {
                Debug.Log("Yay, " + "14 metre");
            }
            else if (distance > 5.2f && distance <= 5.6)
            {
                Debug.Log("Yay, " + "13 metre");
            }
            else if (distance > 4.8f && distance <= 5.2)
            {
                Debug.Log("Yay, " + "12 metre");
            }
            else if (distance > 4.4f && distance <= 4.8)
            {
                Debug.Log("Yay, " + "11  metre");
            }
            else if (distance > 4f && distance <= 4.4)
            {
                Debug.Log("Yay, " + "10  metre");
            }
            else if (distance > 3.6f && distance <= 4)
            {
                Debug.Log("Yay, " + "9 metre");
            }
            else if (distance > 3.2f && distance <= 3.6)
            {
                Debug.Log("Yay, " + "8 metre");
            }
            else if (distance > 2.8f && distance <= 3.2)
            {
                Debug.Log("Yay, " + "7 metre");
            }
            else if (distance > 2.4f && distance <= 2.8)
            {
                Debug.Log("Yay, " + "6 metre");
            }
            else if (distance > 2f && distance <= 2.4)
            {
                Debug.Log("Yay, " + "5 metre");
            }
            else if (distance > 1.6f && distance <= 2)
            {
                Debug.Log("Yay, " + "4 metre");
            }
            else if (distance > 1.2f && distance <= 1.6)
            {
                Debug.Log("Yay, " + "3 metre");
            }
            else if (distance > 0.8f && distance <= 1.2)
            {
                Debug.Log("Yay, " + "2 metre");
            }
            else if (distance > 0.4f && distance <= 0.8)
            {
                Debug.Log("Yay, " + "1 metre");
            }
            else
            {
                Debug.Log("Distance to Player: " + distance + " units");
            }


        }

    }

}
