using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreText.coinAmount += 1;
        Destroy(gameObject);
    }
}
