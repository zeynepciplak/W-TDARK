using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator canAnim;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            PlayerCtrl.movSpeed = 0;
            PlayerCtrl.speedX = 0;
            PlayerCtrl.speedY = 0;

            isCutsceneOn = true;
            canAnim.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene()
    {
        PlayerCtrl.movSpeed = 5;
        isCutsceneOn = false;
        canAnim.SetBool("cutscene1", false);
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
