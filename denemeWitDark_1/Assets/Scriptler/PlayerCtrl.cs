using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject inventory;
    bool invIsActive = false;
    // Bu alttaki ne ise yarıyor bilmiyorum -Ömer
    [SerializeField] float speed;
    public static int swordAmount = 0;

    public GameObject player;
    public GameObject inventoryMenu;
    public GameObject[] inventorySlots;
    public int selectedSlotIndex = 0;

    void Start()
    {
        inventory.SetActive(false);
    }

    void Update()
    {
        if (!invIsActive)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventory.SetActive(true);
                invIsActive = true;
            }
        }
        else
        {
            PlayerMovement.movSpeed = 0;
            PlayerMovement.speedX = 0;
            PlayerMovement.speedY = 0;
            PlayerMovement.rb.velocity = Vector2.zero;

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


/*
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
    public int selectedSlotIndex = 0;

    public bool bruhh = false;

    void Start()
    {
        movSpeed = 5;
        rb = GetComponent<Rigidbody2D>();

        inventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && invIsActive == false)
        {
            inventory.SetActive(true);
            invIsActive = true;

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
            else if (Input.GetKeyDown(KeyCode.W))
            {
                selectedSlotIndex = (selectedSlotIndex - 1 + inventorySlots.Length) % inventorySlots.Length;
                Debug.Log("Seçilen envanter: " + inventorySlots[selectedSlotIndex].name);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                selectedSlotIndex = (selectedSlotIndex + 1) % inventorySlots.Length;
                Debug.Log("Seçilen envanter: " + inventorySlots[selectedSlotIndex].name);
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.I) && invIsActive == true)
        {
            inventory.SetActive(false);
            invIsActive = false;
        }
        
        if(invIsActive == false) { 
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
        }
        else
        {
            movSpeed = 0;
            speedX = 0;
            speedY = 0;
            rb.velocity = Vector2.zero;
        }

    }

    
}
*/