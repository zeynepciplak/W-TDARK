using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(StudioEventEmitter))]
public class VibrObject : MonoBehaviour
{
    private StudioEventEmitter emitter; // FMOD Studio Event Emitter bileşeni

    void Start()
    {
        // FMOD Studio Event Emitter bileşenini al
        emitter = GetComponent<StudioEventEmitter>();
        
        // Sesi çal
        emitter.Play();
    }

    // Trigger girişi olduğunda çağrılır
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer dokunan obje Player ise
        if (collision.gameObject.CompareTag("Player"))
        {
            // FMOD Studio Event Emitter bileşeni varsa ve ses çalıyorsa
            if (emitter != null)
            {
                // Sesin çalmasını durdur
                emitter.Stop();
            }
            
            // Objeyi yok et (Bu scriptin bağlı olduğu oyun nesnesini yok eder)
            Destroy(this.gameObject);

            // Konsola mesaj yazdır
            Debug.Log("sağa doğru git");
        }
    }
}
