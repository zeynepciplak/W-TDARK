using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bowText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int bowAmount = 0;
    public int i = 0;
    GameObject player;

    // :sunglasses:
    public bool bowAktif = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        i = player.GetComponent<PlayerCtrl>().selectedSlotIndex;
        if (text != null)
        {
            text.text = bowAmount.ToString();


            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (i == 1)
                {
                    if (bowAmount > 0)
                    {
                        bowAmount--;
                        Debug.Log("\nYay envanteri azaltýldý. Yeni envanter sayýsý: " + bowAmount);
                        bowAktif = true;
                    }
                }
            }
        }
    }
}
