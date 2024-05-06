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
    GameObject player;

    public bool arrowAktif = false;
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
                if (i == 1)
                {
                    if (arrowAmount > 0)
                    {
                        arrowAmount--;
                        Debug.Log("\nOk envanteri azalt�ld�. Yeni envanter say�s�: " + arrowAmount);
                        arrowAktif = true;
                    }
                }
            }
        }
    }
}
