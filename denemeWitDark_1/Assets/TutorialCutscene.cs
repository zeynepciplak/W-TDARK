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
            PlayerCtrl.movSpeed = 0;
            PlayerCtrl.speedX = 0;
            PlayerCtrl.speedY = 0;

            isCutsceneOn = true;
            Debug.Log("Ho� Geldin sevgili oyuncu! Oyunda hareket etmek i�in 'WASD' tu�lar�n� kullanmal�s�n. Ne yaz�k ki y�n tu�lar� envanter men�s� i�in kullan�l�yor.\n" +
                      "Ekranda D�rt bir yan�nda ki deneme tahtalar� ile g�c�n� test edebilir, �evre ile etkile�ime girmek i�in ise G tu�una basarak radar� kullanabilirsin.\n" +
                      "D��manlar ile d�v��mek i�in radar�n� L tu�u ile d��mana kitlemen ve ard�ndan F tu�u ile sald�r� ger�ekle�tirmen gerekiyor.\n" +
                      "WitDark evreninde ba�ar�lar yolda�");
            Invoke(nameof(StopCutscene), 5f);
            
        }
    }

    void StopCutscene()
    {
        PlayerCtrl.movSpeed = 5;
        isCutsceneOn = false;
        Destroy(gameObject);


    }
}

