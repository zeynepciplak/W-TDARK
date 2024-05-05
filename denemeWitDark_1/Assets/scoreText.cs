using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int coinAmount = 0;
    public int i = 0;
    GameObject player;


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
            text.text = coinAmount.ToString();

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (i == 0)
                {
                    if (coinAmount > 0)
                    {
                        coinAmount--;
                        Debug.Log("\nPara envanteri azaltıldı. Yeni envanter sayısı: " + coinAmount);

                    }
                }
            }
        }
    }
}
