using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class startCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator canAnim;

    
    private TilemapRenderer yeniAltDuvarRenderer;
    // Her biri için mi yapmam gerekiyor dedirtti
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
        }
    }

    void StopCutscene()
    {
        PlayerCtrl.movSpeed = 5;
        isCutsceneOn = false;
        canAnim.SetBool("cutscene1", false);

        yeniAltDuvarRenderer.enabled = true;

        yeniAltDuvarCollider.enabled = true;

        // Tilemap'i ismine göre bulun (benzersiz olduðunu varsayarak)
        GameObject tilemapObject = GameObject.Find("GonnaLostTrees");
        if (tilemapObject != null)
        {
            Destroy(tilemapObject);
        }
        else
        {
            Debug.LogError("Tilemap 'GonnaLostTrees' bulunamadý!");
        }
        
        
        Destroy(gameObject);
        
    
    }
}
