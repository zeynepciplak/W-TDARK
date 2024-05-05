using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject inventory;
    bool invIsActive = false;
    [SerializeField] float speed;

    // public static float movSpeed = 5;
    public static float movSpeed;
    public static float speedX, speedY;
    private Rigidbody2D rb;

    public GameObject player;
    public GameObject inventoryMenu;
    public GameObject[] inventorySlots;
    private int selectedSlotIndex = 0;
    private bool inInventory = false;

    public bool isLoaded2 = false;

    

    void Start()
    {
        movSpeed = 5;
        // Kodlama esnasinda kolaylik saglamasi icin
        // movSpeed = 25; 

        rb = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        /*
        GameObject player = GameObject.Find("Player");
        Scene openWorldScene = SceneManager.GetSceneByName("OpenWorld");
        Scene sampleScene = SceneManager.GetSceneByName("SampleScene 3");

        if (sampleScene.isLoaded && isLoaded2 == false)
        {
            player.transform.position = new Vector3(421.34f, -17.48f, 0);
        }
        else if (openWorldScene.isLoaded )
        {
            isLoaded2 = true;
            player.transform.position = new Vector3(418, -82, 0);
            
        }
        else if (sampleScene.isLoaded && isLoaded2 == true)
        {
            player.transform.position = new Vector3(0, 0, 0);
            
        }
        */

        if (!invIsActive)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movSpeed = 10;
                speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
                speedY = Input.GetAxisRaw("Vertical") * movSpeed;
                rb.velocity = new Vector2(speedX, speedY);
            }
            else
            {
                movSpeed = 5;
                speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
                speedY = Input.GetAxisRaw("Vertical") * movSpeed;
                rb.velocity = new Vector2(speedX, speedY);
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                rb.velocity = Vector2.zero;

                inventory.SetActive(true);
                invIsActive = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                selectedSlotIndex = (selectedSlotIndex - 1 + inventorySlots.Length) % inventorySlots.Length;
                Debug.Log("Seçilen envanter: " + inventorySlots[selectedSlotIndex].name);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                selectedSlotIndex = (selectedSlotIndex + 1) % inventorySlots.Length;
                Debug.Log("Seçilen envanter: " + inventorySlots[selectedSlotIndex].name);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                inventory.SetActive(false);
                invIsActive = false;
                rb.velocity = new Vector2(speedX, speedY); // Hareketi yeniden başlat
            }
        }
    }
}


