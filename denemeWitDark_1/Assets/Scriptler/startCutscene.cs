using UnityEngine;
using UnityEngine.Tilemaps;

public class startCutscene : MonoBehaviour{
    public static bool isCutsceneOn;
    public Animator canAnim;
    private TilemapRenderer yeniAltDuvarRenderer;
    private TilemapCollider2D yeniAltDuvarCollider;
    void Start(){
        yeniAltDuvarRenderer = GameObject.Find("Yeni_AltDuvar").GetComponent<TilemapRenderer>();
        yeniAltDuvarCollider = GameObject.Find("Yeni_AltDuvar").GetComponent<TilemapCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player")
        {
            isCutsceneOn = true;
            canAnim.SetBool("cutscene1", true);
            PlayerMovement.movSpeed = 0;
            PlayerMovement.speedX = 0;
            PlayerMovement.speedY = 0;
            PlayerMovement.rb.velocity = Vector2.zero;
            Invoke(nameof(StopCutscene), 5f);

            
        }  
    }
    void StopCutscene()
    {
        isCutsceneOn = false;
        canAnim.SetBool("cutscene1", false);

        yeniAltDuvarRenderer.enabled = true;
        yeniAltDuvarCollider.enabled = true;

        GameObject tilemapObject = GameObject.Find("GonnaLostTrees");
        if (tilemapObject != null)
            Destroy(tilemapObject);
        else
            Debug.LogError("Tilemap 'GonnaLostTrees' bulunamadý!");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.transform.position = new Vector3(131f, 111f, 0f);
        else
            Debug.LogError("Player object not found!");
        Destroy(gameObject);
    }
}





