using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float healthToGive;//burda ne kadar score yapıcağını tutucaz.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.ComporeTag("Player"))
        {
            collision.GetComponent<...>()....+- healthToGive//bu kısma topladıkça artıcak scorenın fonksiyonunu çağırıcaz.
                Destroy(gameObject);
        }
    }
}
