using UnityEngine;

public class tutorialCutscene2 : MonoBehaviour
{
    public string[] hedefObjelerIsimleri = { "DenemeTahtas� (1)", "DenemeTahtas� (2)", "DenemeTahtas� (3)", "DenemeTahtas�(4)" };

    public static bool isCutsceneOn;
    private bool hasEntered = false; // Tetiklendi mi?

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasEntered)
        {
            // Hedef objelerin hepsi yok oldu�unda cutscene'i ba�lat
            if (hepsiYok())
            {
                hasEntered = true;
                PlayerMovement.movSpeed = 0;
                PlayerMovement.speedX = 0;
                PlayerMovement.speedY = 0;
                PlayerMovement.rb.velocity = Vector2.zero;

                isCutsceneOn = true;
                Debug.Log("Hedef objelerin hepsi yok edildi!\n" +
                          "Tekrar kar��la�ana kadar g�r���r�z yolcu");
                Invoke(nameof(StopCutscene), 5f);
            }
        }
    }

    private bool hepsiYok()
    {
        // Hedef objelerin hepsinin yok olup olmad���n� kontrol edin
        foreach (string hedefObjesiIsmi in hedefObjelerIsimleri)
        {
            GameObject hedefObjesi = GameObject.Find(hedefObjesiIsmi);
            if (hedefObjesi != null)
            {
                return false; // En az bir hedef obje var
            }
        }
        return true; // T�m hedef objeler yok
    }

    void StopCutscene()
    {
        PlayerMovement.movSpeed = 5;
        isCutsceneOn = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.transform.position = new Vector3(215.5f, 26f, 0f);
        else
            Debug.LogError("Player object not found!");
        Destroy(gameObject);
    }
}


