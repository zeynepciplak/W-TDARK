using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Collider bileşeninin zorunlu olduğunu belirtir

public class Vibr : MonoBehaviour
{
    private Transform playerTransform; // Oyuncunun Transform bileşeni
    private bool triggered = false; // Çarpışma durumunu takip etmek için bir bayrak

    void Start()
    {
        // "Player" etiketine sahip objenin Transform bileşenini al
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Eğer oyuncu ile çarpışma olduysa ve daha önce tetiklenmemişse
            if (!triggered)
            {
                Debug.Log("Vibration object collided with the player!"); // Yeni Debug.Log mesajı
                triggered = true; // Tetiklendiğini işaretle
            }
        }
    }
}
