using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tekrarBaslat : MonoBehaviour
{
    public float sureLimiti = 60f; // Yeniden ba�lama s�resi limiti
    private float gecenSure = 0f;
    private Vector3 baslangicNoktasi;

    // Start is called before the first frame update
    void Start()
    {
        baslangicNoktasi = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gecenSure += Time.deltaTime;

        // Belirlenen s�re ge�ti�inde ba�lang�� noktas�na geri d�n
        if (gecenSure >= sureLimiti)
        {
            OyunaBasla();
        }
    }

    void OyunaBasla()
    {
        // Oyunu yeniden ba�latmak i�in sahneyi y�kleyin
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider other)
    {
        // E�er oyuncu belirli bir b�lgeye girerse (�rne�in, �l�m b�lgesi)
        // Ba�lang�� noktas�na geri d�n
        if (other.CompareTag("OlumBolgesi"))
        {
            transform.position = baslangicNoktasi;
            gecenSure = 0f; // S�reyi s�f�rla
        }
    
    }
}