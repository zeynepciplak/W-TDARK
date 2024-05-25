using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class swordText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int swordAmount = 0;
    public int i = 0;
    GameObject player;

    // :sunglasses:
    public static bool swordAktif = false;
    public static SpriteRenderer swordSpriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<TextMeshProUGUI>();

        swordSpriteRenderer = GameObject.Find("sword").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        i = player.GetComponent<PlayerCtrl>().selectedSlotIndex;
        if (text != null)
        {
            text.text = swordAmount.ToString();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (i == 1)
                {
                    if (swordAmount > 0)
                    {
                        swordAmount--;
                        Debug.Log("\nKılıç envanteri azaltıldı. Yeni envanter sayısı: " + swordAmount);
                        
                    }
                    if (swordAmount <= 0)
                    {

                    }
                }
            }
            
            if(Input.GetKeyDown(KeyCode.O))
            {
                if (i == 1)
                {
                    if (swordAmount > 0)
                    {
                        Debug.Log("Kılıç alındı");
                        swordAktif = true;
                        swordSpriteRenderer.enabled = true;

                        arrowText.arrowAktif = false;

                        bowText.bowAktif = false;
                        bowText.bowSpriteRenderer.enabled = false;

                        wandText.wandAktif = false;
                        wandText.wandSpriteRenderer.enabled = false;

                    }
                }
            }
            
        }
    }
    
}
