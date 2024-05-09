using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TutorialCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;

    private bool hasEntered = false; // Tetiklendi mi?

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && !hasEntered)
        {
            hasEntered = true;
            PlayerMovement.movSpeed = 0;
            PlayerMovement.speedX = 0;
            PlayerMovement.speedY = 0;
            PlayerMovement.rb.velocity = Vector2.zero;

            isCutsceneOn = true;
            Debug.Log("Hoþ Geldin sevgili oyuncu! Oyunda hareket etmek için 'WASD' tuþlarýný kullanmalýsýn. Ne yazýk ki yön tuþlarý envanter menüsü için kullanýlýyor.\n" +
                      "Ekranda Dört bir yanýnda ki deneme tahtalarý ile gücünü test edebilir, çevre ile etkileþime girmek için ise G tuþuna basarak radarý kullanabilirsin.\n" +
                      "Düþmanlar ile dövüþmek için radarýný L tuþu ile düþmana kitlemen ve ardýndan F tuþu ile saldýrý gerçekleþtirmen gerekiyor.\n" +
                      "WitDark evreninde baþarýlar yoldaþ");
            Invoke(nameof(StopCutscene), 5f);
            
        }
    }

    void StopCutscene()
    {
        isCutsceneOn = false;
        Destroy(gameObject);


    }
}

