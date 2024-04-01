using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class startCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator canAnim;

    
    private TilemapRenderer yeniAltDuvarRenderer;
    // Her biri i�in mi yapmam gerekiyor dedirtti
    private TilemapCollider2D yeniAltDuvarCollider;
    void Start()
    {
        // Get reference to the tilemap in Start()
        
        yeniAltDuvarRenderer = GameObject.Find("Yeni_AltDuvar").GetComponent<TilemapRenderer>();
        yeniAltDuvarCollider = GameObject.Find("Yeni_AltDuvar").GetComponent<TilemapCollider2D>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            PlayerCtrl.movSpeed = 0;
            PlayerCtrl.speedX = 0;
            PlayerCtrl.speedY = 0;

            isCutsceneOn = true;
            canAnim.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 5f);


            AudioManager.instance.PlayAudio(AudioManager.instance.thunderAS);


            


        }


    }

    void StopCutscene()
    {
        PlayerCtrl.movSpeed = 5;
        isCutsceneOn = false;
        canAnim.SetBool("cutscene1", false);

        yeniAltDuvarRenderer.enabled = true;

        yeniAltDuvarCollider.enabled = true;

        // Tilemap'i ismine g�re bulun (benzersiz oldu�unu varsayarak)
        GameObject tilemapObject = GameObject.Find("GonnaLostTrees");
        if (tilemapObject != null)
        {
            Destroy(tilemapObject);
        }
        else
        {
            Debug.LogError("Tilemap 'GonnaLostTrees' bulunamad�!");
        }


        // Set player position to (113, 30) after cutscene ends
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Assuming your player has the "Player" tag
        if (player != null)
        {
            player.transform.position = new Vector3(113f, 30f, 0f); // Set position based on your 2D or 3D environment
        }
        else
        {
            Debug.LogError("Player object not found!");
        }

        Destroy(gameObject);
        
    
    }
}
