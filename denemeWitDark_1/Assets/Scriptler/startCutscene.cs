using UnityEngine;
using UnityEngine.Tilemaps;

public class startCutscene : MonoBehaviour{
    public static bool isCutsceneOn;
    public Animator canAnim;
    private TilemapRenderer yeniAltDuvarRenderer;
    private TilemapCollider2D yeniAltDuvarCollider;

    public AudioManager audioManager;


    void Start(){
        yeniAltDuvarRenderer = GameObject.Find("Yeni_AltDuvar").GetComponent<TilemapRenderer>();
        yeniAltDuvarCollider = GameObject.Find("Yeni_AltDuvar").GetComponent<TilemapCollider2D>();

        audioManager = AudioManager.instance;


    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player")
        {
            PlayerCtrl.movSpeed = 0;
            PlayerCtrl.speedX = 0;
            PlayerCtrl.speedY = 0;

            isCutsceneOn = true;
            canAnim.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 5f);
        }  
    }
    void StopCutscene()
    {
        PlayerCtrl.movSpeed = 5;
        isCutsceneOn = false;
        canAnim.SetBool("cutscene1", false);

        yeniAltDuvarRenderer.enabled = true;
        yeniAltDuvarCollider.enabled = true;

        GameObject tilemapObject = GameObject.Find("GonnaLostTrees");
        if (tilemapObject != null)
            Destroy(tilemapObject);
        else
            Debug.LogError("Tilemap 'GonnaLostTrees' bulunamad�!");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.transform.position = new Vector3(131f, 111f, 0f);
        else
            Debug.LogError("Player object not found!");
        Destroy(gameObject);
    }
}





