using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite redSmoothCross; // Deðiþtirilmiþ sprite
    public Sprite ilkSprite;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "PlayerLight")
        {
            
            /*
            PlayerCtrl.movSpeed = 0;
            PlayerCtrl.speedX = 0;
            PlayerCtrl.speedY = 0;
            */
            Debug.Log("Deðdim");
            spriteRenderer.sprite = redSmoothCross;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerLight")
        {
            spriteRenderer.sprite = ilkSprite;
        }
    }
}
