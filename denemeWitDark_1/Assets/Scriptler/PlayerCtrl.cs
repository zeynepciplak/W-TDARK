using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    // public static float movSpeed = 5;
    public static float movSpeed;
    public static float speedX, speedY;
    Rigidbody2D rb;

    void Start()
    {
        movSpeed = 5;
        // Kodlama esnasýnda kolaylýk saðlamasý için
        // movSpeed = 25; 

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);
    }
}







    /*
    void RestartGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
    System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", "") + ".exe");
#endif
    }
    */




