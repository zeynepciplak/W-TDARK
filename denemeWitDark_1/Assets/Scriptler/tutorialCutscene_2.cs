using UnityEngine;

public class tutorialCutscene2 : MonoBehaviour
{
    public string[] hedefObjelerIsimleri = { "DenemeTahtası (1)", "DenemeTahtası (2)", "DenemeTahtası (3)", "DenemeTahtası(4)" };

    public static bool isCutsceneOn;
    private bool hasEntered = false; // Tetiklendi mi?

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasEntered)
        {
            // Hedef objelerin hepsi yok olduğunda cutscene'i başlat
            if (hepsiYok())
            {
                hasEntered = true;
                PlayerCtrl.movSpeed = 0;
                PlayerCtrl.speedX = 0;
                PlayerCtrl.speedY = 0;
                isCutsceneOn = true;
                Debug.Log("Hedef objelerin hepsi yok edildi!\n" +
                          "Tekrar karşılaşana kadar görüşürüz yolcu");
                Invoke(nameof(StopCutscene), 5f);
            }
        }
    }

    private bool hepsiYok()
    {
        // Hedef objelerin hepsinin yok olup olmadığını kontrol edin
        foreach (string hedefObjesiIsmi in hedefObjelerIsimleri)
        {
            GameObject hedefObjesi = GameObject.Find(hedefObjesiIsmi);
            if (hedefObjesi != null)
            {
                return false; // En az bir hedef obje var
            }
        }
        return true; // Tüm hedef objeler yok
    }

    void StopCutscene()
    {
        PlayerCtrl.movSpeed = 5;
        isCutsceneOn = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.transform.position = new Vector3(215.5f, 26f, 0f);
        else
            Debug.LogError("Player object not found!");
        Destroy(gameObject);
    }
}


