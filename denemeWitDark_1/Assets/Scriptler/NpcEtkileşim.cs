using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


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
public class NpcEtkileşim : MonoBehaviour { 
private void OnTriggerEnter2D(Collider2D collision)
{
    /*
    if (collision.gameObject.CompareTag("Player")) // Check if colliding with "Player" tag
    {
        ScoreText.coinAmount += 1;
        Destroy(gameObject);
    }
    */
    if (collision.gameObject.CompareTag("Player"))

    {
            Debug.Log("Npc ile etkileşime girdiniz.");
    }
    

}
    
}