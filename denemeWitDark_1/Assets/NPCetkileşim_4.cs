using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCetkileşim_4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("NPC ile etkileşime girmek için E'ye basınız.");
        }
    }
}