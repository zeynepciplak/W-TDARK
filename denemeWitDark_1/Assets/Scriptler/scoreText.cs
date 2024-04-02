using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
     Text text; // text değişkeni oluşturuldu.

    public static int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        // text = GetComponent<Text>(); // Bu satır gereksiz, zaten text değişkeni yukarıda tanımlı.
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
    }
   

}
