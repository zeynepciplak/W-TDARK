using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class arrowText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int arrowAmount = 0;
    public int i = 0;
    public GameObject player;

    public static bool arrowAktif = false;
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
            text.text = arrowAmount.ToString();


            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (i == 2)
                {
                    if (arrowAmount > 0)
                    {
                        arrowAmount--;
                        Debug.Log("\nOk envanteri azaltýldý. Yeni envanter sayýsý: " + arrowAmount);
                        
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (i == 2)
                {
                    if (arrowAmount > 0)
                    {
                        Debug.Log("Ok alýndý");
                        arrowAktif = true;
                        bowText.bowAktif = false;
                        swordText.swordAktif = false;


                    }
                }
            }
            
        }
    }
}
