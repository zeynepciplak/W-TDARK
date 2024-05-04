using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text text; // text değişkeni oluşturuldu.
    public static int coinAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>(); // Bu satır gereksiz, zaten text değişkeni yukarıda tanımlı.
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null) // Check if text is assigned before accessing it
        {
            text.text = coinAmount.ToString();
        }
    }


}
