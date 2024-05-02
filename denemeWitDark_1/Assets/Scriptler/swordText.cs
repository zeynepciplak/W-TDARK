using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class swordText : MonoBehaviour
{
    public TextMeshProUGUI text; // TextMeshProUGUI türünde bir değişken tanımlayın.

    public static int swordAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<TextMeshProUGUI>() metoduyla text nesnesini alın.
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Text nesnesi atanmışsa, metni güncelleyin.
        if (text != null)
        {
            text.text = swordAmount.ToString();
        }
    }
}
