using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum GridType
{
    Ground,
    Grass,
    Stone
}
public class PlayerCtrl : MonoBehaviour
{


    // public static float movSpeed = 5;
    public static float movSpeed;
    public static float speedX, speedY;
    private Rigidbody2D rb;
    
    private GridType currentGridType = GridType.Ground; // Başlangıçta zeminde olduğumuzu varsayalım

    private bool isMoving = false; // Hareket ediyor mu kontrolü

    public AudioManager audioManager;

    void Start()
    {
        movSpeed = 5;
        // Kodlama esnasýnda kolaylýk saðlamasý için
        // movSpeed = 25; 

        rb = GetComponent<Rigidbody2D>();
        audioManager = AudioManager.instance;
    if (audioManager == null)
    {
        Debug.LogError("AudioManager instance is not found!");
    }

       
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        // Hareket kontrolü
        isMoving = Mathf.Abs(speedX) > 0.1f || Mathf.Abs(speedY) > 0.1f;

        // Hareket ediyorsa yürüme sesini çal
        if (isMoving)
        {
            PlayFootstepSound();
        }

        // Grid türünü güncelle (tag'lere göre)
        UpdateGridType();
    }

    void UpdateGridType()
    {
        // Oyuncunun bulunduğu grid türünü tag'lere göre belirle
        if (IsOnTag("ground"))
        {
            currentGridType = GridType.Ground;
        }
        else if (IsOnTag("cali"))
        {
            currentGridType = GridType.Grass;
        }
        else if (IsOnTag("stone"))
        {
            currentGridType = GridType.Stone;
        }
        
    }

    bool IsOnTag(string tag)
    {
        // Oyuncunun bulunduğu tag'ı kontrol et
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f); // Oyuncunun altındaki collider'ları al (0.1f yarıçapıyla)
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == tag)
            {
                return true;
            }
        }
        return false;
    }

    void PlayFootstepSound()
    {
        // AudioManager üzerinden grid türüne göre yürüme sesini çal
        switch (currentGridType)
        {
            case GridType.Ground:
                audioManager.PlayAudio(audioManager.wotfAS);
                break;
            case GridType.Grass:
                audioManager.PlayAudio(audioManager.wotgAS);
                break;
            case GridType.Stone:
                audioManager.PlayAudio(audioManager.wotlAS);
                break;
            default:
                Debug.LogWarning("Unknown grid type!");
                break;
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




