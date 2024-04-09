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
    bool isWalkingOnGrass; // Çalı üzerinde mi yürünüyor?
    bool isWalkingOnStone; // Taş üzerinde mi yürünüyor?

    bool isWalkingOnForest; // Orman zemininde mi yürünüyor?

    public AudioManager audioManager;

    void Start()
    {
        movSpeed = 5;
        // Kodlama esnasýnda kolaylýk saðlamasý için
        // movSpeed = 25; 

        rb = GetComponent<Rigidbody2D>();
        audioManager = AudioManager.instance;
       
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            isWalkingOnForest = true;
            audioManager.PlayAudio(audioManager.wotfAS); // Normal yol üzerinde wotf sesini çal
        }
        if (collision.CompareTag("cali"))
        {
            isWalkingOnGrass = true;
            audioManager.PlayAudio(audioManager.wotgAS); // Çalıya girdiğinde wotf sesini çal
        }

        if (collision.CompareTag("stone"))
        {
            isWalkingOnStone = true;
            audioManager.PlayAudio(audioManager.wotlAS); // Logoya girdiğinde wotl sesini çal
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {   
        if (collision.CompareTag("ground"))
        {
            isWalkingOnForest = false;
        }
        if (collision.CompareTag("cali"))
        {
            isWalkingOnGrass = false;
        }

        if (collision.CompareTag("stone"))
        {
            isWalkingOnStone = false;
        }
    }


}







        /*
        if (elapsedTime >= restartTime)
        {
            RestartGame();
        }
        */

        // Karakter yÃ¼rÃ¼rken wotf sesi Ã§al
        
        /*
        if (rb.velocity.magnitude > 0 && !isWalkingOnBush && !isWalkingOnStone)
        {
            audioManager.PlayAudio(audioManager.wotgAS);
        }
       
    }
        */

   /* void OnTriggerEnter2D(Collider2D collision)
    {
        // ÃalÄ±lardan geÃ§erken wot sesi Ã§al
        if (collision.CompareTag("Bush"))
        {
            isWalkingOnBush = true;
            audioManager.PlayAudio(audioManager.wotfAS);
        }

        // TaÅÄ±n Ã¼stÃ¼nden geÃ§erken 3. sesi Ã§al
        if (collision.CompareTag("Stone"))
        {
            isWalkingOnStone = true;
            audioManager.PlayAudio(audioManager.wotlAS);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // ÃalÄ±lardan veya taÅÄ±n Ã¼stÃ¼nden Ã§Ä±kÄ±nca sesi durdur
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




