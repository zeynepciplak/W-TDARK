using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class wandText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int wandAmount = 0;
    public int i = 0;
    GameObject player;

    // :sunglasses:
    public static bool wandAktif = false;
    public static SpriteRenderer wandSpriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<TextMeshProUGUI>();

        //:sunglasses:
        wandSpriteRenderer = GameObject.Find("wand").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        i = player.GetComponent<PlayerCtrl>().selectedSlotIndex;
        if (text != null)
        {
            text.text = wandAmount.ToString();


            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (i == 3)
                {
                    if (wandAmount > 0)
                    {
                        wandAmount--;
                        Debug.Log("\nAsa envanteri azalt�ld�. Yeni envanter say�s�: " + wandAmount);

                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                if (i == 3)
                {
                    if (wandAmount > 0)
                    {
                        Debug.Log("Asa al�nd�");
                        wandAktif = true;
                        wandSpriteRenderer.enabled = true;

                        arrowText.arrowAktif = false;

                        bowText.bowAktif = false;
                        bowText.bowSpriteRenderer.enabled = false;                        

                        swordText.swordAktif = false;
                        swordText.swordSpriteRenderer.enabled = false;

                    }
                }

            }

        }
    }
}
