
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class openWorldGidis : MonoBehaviour
{
    public static bool isCutsceneOn;
    private bool hasEntered = false; // Tetiklendi mi?

    [SerializeField] private string OpenWorld;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasEntered)
        {
            hasEntered = true;
            PlayerMovement.movSpeed = 0;
            PlayerMovement.speedX = 0;
            PlayerMovement.speedY = 0;
            PlayerMovement.rb.velocity = Vector2.zero;

            isCutsceneOn = true;

            Invoke(nameof(StopCutscene), 5f);
        }
    }

    void StopCutscene()
    {
        PlayerMovement.movSpeed = 5;
        isCutsceneOn = false;

        // Sahneyi yükle
        //SceneManager.LoadScene(OpenWorld);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Sahneyi yüklemeden önce karakterin konumunu kaydet
        Vector3 playerPosition = new Vector3(0f, -1f, 0f);

        // Sahneyi yükledikten sonra karakteri bul ve konumunu ayarla
        StartCoroutine(SetPlayerPosition(playerPosition));

        Debug.Log("Hemon Topraklari");

        Destroy(gameObject);
    }

    IEnumerator SetPlayerPosition(Vector3 position)
    {
        yield return new WaitForEndOfFrame(); // Bir sonraki kareyi bekle

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = position;
            
        }
        else
        {
            Debug.LogError("Player object not found!");
        }
    }
}