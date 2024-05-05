using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int swordAmount = 0;
    public int slot1 = 0;
    public int slot2 = 0;
    public int slot3 = 0;
    public int slot4 = 0;
    public int slot5 = 0;
    public int slot6 = 0;

    public bool slot1isEmpty;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        i = player.GetComponent<PlayerCtrl>().selectedSlotIndex;
        if (text != null)
        {
            text.text = coinAmount.ToString();

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (i == 0)
                {
                    if (coinAmount > 0)
                    {
                        coinAmount--;
                        Debug.Log("\nPara envanteri azaltýldý. Yeni envanter sayýsý: " + coinAmount);

                    }
                }
            }
        }
        */
    }
}
