using UnityEngine;

public class PlayerTeleportScript : MonoBehaviour
{
    public Transform teleportPosition; // Işınlanma hedef pozisyonu (ör. yan oyun alanının başı)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Gardiyan ile temas edildiğinde
        if (other.CompareTag("Gardiyan"))
        {
            // Player'ı teleportPosition pozisyonuna ışınlama
            transform.position = teleportPosition.position;
        }
    }
}
