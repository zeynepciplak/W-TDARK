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
    bool isWalkingOnBush;
    bool isWalkingOnStone;

    public AudioManager audioManager;

   
    /*
    // public float timeBeforeClosure = 60f; // Time before game closure in seconds
    public float restartTime = 10f;
    private float elapsedTime = 0f;
    */

    void Start()
    {
        movSpeed = 25;
        // movSpeed = 3;
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        /*
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= restartTime)
        {
            RestartGame();
        }
        */

        // Karakter yürürken wotf sesi çal
        if (rb.velocity.magnitude > 0 && !isWalkingOnBush && !isWalkingOnStone)
        {
            audioManager.PlayAudio(audioManager.wotgAS);
        }
       
    }

   /* void OnTriggerEnter2D(Collider2D collision)
    {
        // Çalılardan geçerken wot sesi çal
        if (collision.CompareTag("Bush"))
        {
            isWalkingOnBush = true;
            audioManager.PlayAudio(audioManager.wotfAS);
        }

        // Taşın üstünden geçerken 3. sesi çal
        if (collision.CompareTag("Stone"))
        {
            isWalkingOnStone = true;
            audioManager.PlayAudio(audioManager.wotlAS);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Çalılardan veya taşın üstünden çıkınca sesi durdur
        if (collision.CompareTag("Bush"))
        {
            isWalkingOnBush = false;
        }

        if (collision.CompareTag("Stone"))
        {
            isWalkingOnStone = false;
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



}
