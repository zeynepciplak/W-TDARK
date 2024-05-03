using System;
using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        movSpeed = 5;
        // Kodlama esnasinda kolaylik saglamasi icin
        // movSpeed = 25; 

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
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
            }
        }
    }
}


