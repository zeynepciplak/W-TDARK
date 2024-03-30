using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tekrarBaslat : MonoBehaviour
{
    public float sureLimiti = 60f; // Yeniden baþlama süresi limiti
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

        // Belirlenen süre geçtiðinde baþlangýç noktasýna geri dön
        if (gecenSure >= sureLimiti)
        {
            OyunaBasla();
        }
    }

    void OyunaBasla()
    {
        // Oyunu yeniden baþlatmak için sahneyi yükleyin
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider other)
    {
        // Eðer oyuncu belirli bir bölgeye girerse (örneðin, ölüm bölgesi)
        // Baþlangýç noktasýna geri dön
        if (other.CompareTag("OlumBolgesi"))
        {
            transform.position = baslangicNoktasi;
            gecenSure = 0f; // Süreyi sýfýrla
        }
    
    }
}