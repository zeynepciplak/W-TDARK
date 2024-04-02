using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class PlayerEtkileşim : MonoBehaviour
{
    public float interactionDistance = 3f; // NPC ile etkileşim mesafesi
    private GameObject currentNPC; // NPC ile etkileşimde bulunulan anki nesne

    void Update()
    {
        // Player'ın önünde bir ray oluşturarak NPC'yi algılama
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Ray NPC'ye çarparsa ve NPC bir tag'e sahipse ("NPC" olarak kabul edelim)
            if (hit.collider.CompareTag("NPC"))
            {
                // NPC'yi kaydet
                currentNPC = hit.collider.gameObject;

                // Etkileşim tuşuna basıldığında
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // NPC'ye etkileşim fonksiyonunu çağır
                    InteractWithNPC();
                }
            }
        }
        else
        {
            // Eğer ray bir NPC'ye çarpmazsa, etkileşim yapılacak NPC'yi null'a ayarla
            currentNPC = null;
        }
    }

    void InteractWithNPC()
    {
        // NPC'yi kontrol et
        NpcEtkileşim npcInteraction = currentNPC.GetComponent<NpcEtkileşim>();
        if (npcInteraction != null)
        {
            // NPC'nin etkileşime yanıt vermesini sağla
            npcInteraction.RespondToInteraction();
        }
    }
}
*/