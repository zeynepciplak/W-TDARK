using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class coinbar : MonoBehaviour
{
    public float maxCoin;
    float currentCoin;
    public Image coinbar;
    // Use this for initialization
    void Start()
    {
        currentCoin = maxCoin;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCoin>=maxCoin)
        {
            currentCoin = maxCoin;
        }
        coinbar.fillAmount = currentCoin / 100;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            currentCoin -= collision.GetComponent<Item>().damage;


            if(currentCoin<=0)
            {
                currentCoin = 0;
                Destroy(gameObject);
            }
        }
    }
}
