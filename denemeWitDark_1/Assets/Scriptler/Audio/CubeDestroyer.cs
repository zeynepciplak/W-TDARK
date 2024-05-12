using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    private AudioManager audioManager; // AudioManager nesnesine erişmek için referans
    public GameObject Vibration;
    private void Start()
    {
        // AudioManager nesnesine erişim sağla
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("AudioManager instance not found!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sadece "Player" etiketine sahip nesneleri kontrol et
        if (other.CompareTag("Player"))
        {
            // Ses olayını durdur
            audioManager.StopEvent(Vibration);

            // Bu nesneyi yok et
            Destroy(other.gameObject);
        }
    }
}
