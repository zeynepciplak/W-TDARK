using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using FMODUnity;
using FMOD.Studio;

public class TutorialCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;

    private bool hasEntered = false; // Tetiklendi mi?

    public StudioEventEmitter cutsceneSoundEmitter;

    

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
            Debug.Log("Ho� Geldin sevgili oyuncu! Oyunda hareket etmek i�in 'WASD' tu�lar�n� kullanmal�s�n. Ne yaz�k ki y�n tu�lar� envanter men�s� i�in kullan�l�yor.\n" +
                      "Ekranda D�rt bir yan�nda ki deneme tahtalar� ile g�c�n� test edebilir, �evre ile etkile�ime girmek i�in ise G tu�una basarak radar� kullanabilirsin.\n" +
                      "D��manlar ile d�v��mek i�in radar�n� L tu�u ile d��mana kitlemen ve ard�ndan F tu�u ile sald�r� ger�ekle�tirmen gerekiyor.\n" +
                      "WitDark evreninde ba�ar�lar yolda�");
            Invoke(nameof(StopCutscene), 5f);

            // Sahne başladığında sesi çal
            cutsceneSoundEmitter.Play();
            
        }
    }

    void StopCutscene()
    {
        isCutsceneOn = false;
          // Sahne durduğunda sesi durdur
        cutsceneSoundEmitter.Stop();
        Destroy(gameObject);


    }
}

