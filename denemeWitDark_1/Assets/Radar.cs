using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite redSmoothCross; // Değiştirilmiş sprite
    public Sprite ilkSprite;

    private Transform playerTransform;
    public int can = 100;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "PlayerLight")
        {
            spriteRenderer.sprite = redSmoothCross;

            //int metre = 19;
            float distance = Vector3.Distance(transform.position, playerTransform.position);

            /*
            for(float i = 8; i<=0; i=(i-0.4f))
            {
                if(distance > 8)
                {
                    Debug.Log("20 metre");
                }
                if (distance > i-0.4f && distance <= i)
                {
                    Debug.Log(metre + "");
                }
                metre = metre - 1;
            }
            */

            if (distance > 8)
            {
                Debug.Log(" Deneme Tahtasi, " + "20 metre, " + can + " hp");
            }
            else if (distance > 7.6f && distance <= 8)
            {
                Debug.Log(" Deneme Tahtasi, " + "19 metre, " + can + " hp");
            }
            else if (distance > 7.2f && distance <= 7.6)
            {
                Debug.Log(" Deneme Tahtasi, " + "18 metre, " + can + " hp");
            }
            else if (distance > 6.8f && distance <= 7.2)
            {
                Debug.Log(" Deneme Tahtasi, " + "17 metre, " + can + " hp");
            }
            else if (distance > 6.4f && distance <= 6.8)
            {
                Debug.Log(" Deneme Tahtasi, " + "16 metre, " + can + " hp");
            }
            else if (distance > 6f && distance <= 6.4)
            {
                Debug.Log(" Deneme Tahtasi, " + "15 metre, " + can + " hp");
            }
            else if (distance > 5.6f && distance <= 6)
            {
                Debug.Log(" Deneme Tahtasi, " + "14 metre, " + can + " hp");
            }
            else if (distance > 5.2f && distance <= 5.6)
            {
                Debug.Log(" Deneme Tahtasi, " + "13 metre, " + can + " hp");
            }
            else if (distance > 4.8f && distance <= 5.2)
            {
                Debug.Log(" Deneme Tahtasi, " + "12 metre, " + can + " hp");
            }
            else if (distance > 4.4f && distance <= 4.8)
            {
                Debug.Log(" Deneme Tahtasi, " + "11 metre, " + can + " hp");
            }
            else if (distance > 4f && distance <= 4.4)
            {
                Debug.Log(" Deneme Tahtasi, " + "10 metre, " + can + " hp");
            }
            else if (distance > 3.6f && distance <= 4)
            {
                Debug.Log(" Deneme Tahtasi, " + "9 metre, " + can + " hp");
            }
            else if (distance > 3.2f && distance <= 3.6)
            {
                Debug.Log(" Deneme Tahtasi, " + "8 metre, " + can + " hp");
            }
            else if (distance > 2.8f && distance <= 3.2)
            {
                Debug.Log(" Deneme Tahtasi, " + "7 metre, " + can + " hp");
            }
            else if (distance > 2.4f && distance <= 2.8)
            {
                Debug.Log(" Deneme Tahtasi, " + "6 metre, " + can + " hp");
            }
            else if (distance > 2f && distance <= 2.4)
            {
                Debug.Log(" Deneme Tahtasi, " + "5 metre, " + can + " hp");
            }
            else if (distance > 1.6f && distance <= 2)
            {
                Debug.Log(" Deneme Tahtasi, " + "4 metre, " + can + " hp");
            }
            else if (distance > 1.2f && distance <= 1.6)
            {
                Debug.Log(" Deneme Tahtasi, " + "3 metre, " + can + " hp");
            }
            else if (distance > 0.8f && distance <= 1.2)
            {
                Debug.Log(" Deneme Tahtasi, " + "2 metre, " + can + " hp");
            }
            else if (distance > 0.4f && distance <= 0.8)
            {
                Debug.Log(" Deneme Tahtasi, " + "1 metre, " + can + " hp");
            }
            else
            {
                Debug.Log("Distance to Player: " + distance + " units"); 
            }


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerLight")
        {
            spriteRenderer.sprite = ilkSprite;
        }
    }
}
