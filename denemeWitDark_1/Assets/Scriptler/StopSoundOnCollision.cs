using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(StudioEventEmitter))]
public class StopSoundOnCollision : MonoBehaviour
{
    private StudioEventEmitter emitter; // FMOD Studio Event Emitter bileşeni

    private bool soundPlaying = false; // Sesin çalınıp çalınmadığını izlemek için bir bayrak

    void Start()
    {
        // AudioManager örneğini alın
        AudioManager audioManager = AudioManager.instance;

        // "Player" etiketine sahip objenin Transform bileşenini al
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // FMOD Studio Event Emitter bileşenini başlatın
        //emitter = audioManager.InitializeEventEmitter(FMODEvents.instance.coinI, this.gameObject);

        // Eğer emitter başarıyla başlatıldıysa ve ses çalınmıyorsa
        if (emitter != null && !soundPlaying)
        {
            // Ses çalınmaya başla
            emitter.Play();

            // Sesin çalındığını belirten bayrağı true yap
            soundPlaying = true;
        }
    }

    // Trigger girişi olduğunda çağrılır
    private void OnTriggerEnter(Collider collision)
    {
        // Eğer dokunan obje Player ise
        if (collision.gameObject.CompareTag("Player"))
        {
            // FMOD Studio Event Emitter bileşeni ve ses çalınıyorsa
            if (emitter != null && soundPlaying)
            {
                // Sesin çalmasını durdur
                emitter.Stop();

                // Objeyi yok et (Bu scriptin bağlı olduğu oyun nesnesini yok eder)
                Destroy(this.gameObject);

                // Sesin çalındığını belirten bayrağı false yap
                soundPlaying = false;

                // Konsola mesaj yazdır
                Debug.Log("Ses durduruldu ve obje yok edildi.");
            }
        }
    }
}
