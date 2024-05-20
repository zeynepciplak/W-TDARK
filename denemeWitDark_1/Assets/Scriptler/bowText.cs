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
    public static bool bowAktif = false;
    public static SpriteRenderer bowSpriteRenderer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<TextMeshProUGUI>();

        bowSpriteRenderer = GameObject.Find("bow").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        i = player.GetComponent<PlayerCtrl>().selectedSlotIndex;
        if (text != null)
        {
            text.text = bowAmount.ToString();


            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (i == 0)
                {
                    if (bowAmount > 0)
                    {
                        bowAmount--;
                        Debug.Log("\nYay envanteri azaltýldý. Yeni envanter sayýsý: " + bowAmount);
                        
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (i == 0)
                {
                    if (bowAmount > 0)
                    {
                        Debug.Log("Yay alýndý");
                        bowAktif = true;
                        bowSpriteRenderer.enabled = true;

                        arrowText.arrowAktif = false;

                        swordText.swordAktif = false;
                        swordText.swordSpriteRenderer.enabled = false;

                        wandText.wandAktif = false;
                        wandText.wandSpriteRenderer.enabled = false;

                    }
                }

            }
            
        }
    }
}
