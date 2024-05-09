using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayAttack : MonoBehaviour
{
    public float enemyMaxHP = 100;
    private float enemyCurrentHP;

    private Transform playerTransform;
    public static float damageAmount = 15;

    // :sunglasses:
    GameObject player;
    public bool bowSecili = false;
    public bool arrowSecili = false;
    public bool swordSecili = false;
    void Start()
    {
        enemyCurrentHP = enemyMaxHP;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(bowText.bowAktif == true && swordText.swordAktif == false && arrowText.arrowAktif == false) {
                damageAmount = 15;
                TakeDamage();
            }
            else if (swordText.swordAktif == true && bowText.bowAktif == false && arrowText.arrowAktif == false)
            {
                damageAmount = 30;
                TakeDamage();
            }
            else if (swordText.swordAktif == false && bowText.bowAktif == false && arrowText.arrowAktif == true)
            {
                damageAmount = 45;
                TakeDamage();
            }
        }
    }
    public void TakeDamage()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= 2)
        {
            enemyCurrentHP -= damageAmount;
            if (enemyCurrentHP <= 0)
            {
                Die();
            }

            if (enemyCurrentHP >= 0)
            {
                Debug.Log("Can seviyesi: " + enemyCurrentHP);
            }
        }
    }

    void Die()
    {
        // Düþmanýn ölümüyle ilgili iþlemler burada gerçekleþtirilir
        Destroy(gameObject); // Düþmaný yok et
    }
}




    

