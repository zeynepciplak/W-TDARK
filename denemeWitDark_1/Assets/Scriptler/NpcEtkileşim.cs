using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using TMPro;


/*public class NpcEtkileşim : MonoBehaviour
{
    // NPC'nin etkileşim sırasında söyleyeceği mesaj
    public string interactionMessage = "Merhaba, nasıl yardımcı olabilirim?";

    // Etkileşim gerçekleştiğinde çağrılacak fonksiyon
    public void RespondToInteraction()
    {
        Debug.Log("Merhaba, nasıl yardımcı olabilirim?");
        // Buraya NPC'nin yapması gereken diğer işlemleri eklenecek.
    }
}
*/

/*
public class NpcEtkileşim : MonoBehaviour
{
    // NPC'nin etkileşim sırasında söyleyeceği mesaj
    public string interactionMessage = "Merhaba, nasıl yardımcı olabilirim?";

    // Etkileşim gerçekleştiğinde çağrılacak fonksiyon
    public void RespondToInteraction()
    {
        Debug.Log(interactionMessage);
        // Debug.Log($"{otherNpc.name} ile etkileşime girildi!");
    }
}
*/

public class NpcKonusma : MonoBehaviour
{
    // NPC'nin konuşma metni
    public string[] konusmaMetni;

    private int metinIndex = 0; // Konuşma metninde hangi metnin gösterileceğini takip eden değişken

    void Start()
    {
        // Metin dosyasını oku
        konusmaMetni = new string[] { "Merhaba, nasıl yardımcı olabilirim?" };

        // Dizi boyutunu kontrol et
        if (konusmaMetni.Length <= metinIndex)
        {
            Debug.LogError("Dizi boyutu yetersiz!");
        }
    }

    public void KonusmayaBasla()
    {
        // Konuşma metnini göster
        if (metinIndex < konusmaMetni.Length)
        {
            Debug.Log(konusmaMetni[metinIndex]);
            metinIndex++;
        }
        else
        {
            // Konuşma bittiğinde metin indexini sıfırla
            metinIndex = 0;
        }
    }
}





















