using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayAttack : MonoBehaviour
{
    public float boss1_MaxHP = 1000;
    private float boss1_CurrentHP;

    public float crook1_MaxHP = 100;
    private float crook1_CurrentHP;

    public float crook2_MaxHP = 150;
    private float crook2_CurrentHP;

    private Transform playerTransform;
    private Transform boss1Transform;
    private Transform crook1Transform;
    private Transform crook2Transform;

    public static float damageAmount = 15;

    // :sunglasses:
    public GameObject player;
    private GameObject boss1;
    private GameObject crook1;
    private GameObject crook2;

    public bool bowSecili = false;
    public bool arrowSecili = false;
    public bool swordSecili = false;

    void Start()
    {
        
        player = GameObject.Find("Player");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = playerTransform.position;

        boss1_CurrentHP = boss1_MaxHP;
        boss1 = GameObject.Find("boss1");
        boss1Transform = GameObject.FindGameObjectWithTag("boss1").transform;

        crook1_CurrentHP = crook1_MaxHP;
        crook1 = GameObject.Find("crook1");
        crook1Transform = GameObject.FindGameObjectWithTag("crook1").transform;

        crook2_CurrentHP = crook2_MaxHP;
        crook2 = GameObject.Find("crook2");
        crook2Transform = GameObject.FindGameObjectWithTag("crook2").transform;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bowText.bowAktif == true && swordText.swordAktif == false && arrowText.arrowAktif == false)
            {
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
        if (boss1Transform != null)
        {
            float distance3 = Vector3.Distance(playerTransform.position, boss1Transform.position);
            if (distance3 <= 2)
            {
                boss1_CurrentHP -= damageAmount;
                if (boss1_CurrentHP <= 0)
                {
                    Destroy(boss1);
                    boss1Transform = null;
                }

                else
                {
                    Debug.Log("Can seviyesi: " + boss1_CurrentHP);
                }
            }
        }

        if (crook1Transform != null)
        {
            float distance = Vector3.Distance(playerTransform.position, crook1Transform.position);
            if (distance <= 2)
            {
                crook1_CurrentHP -= damageAmount;
                if (crook1_CurrentHP <= 0)
                {
                    Destroy(crook1);
                    crook1Transform = null;
                }

                else
                {
                    Debug.Log("Can seviyesi: " + crook1_CurrentHP);
                }
            }
        }

        if (crook2Transform != null)
        {
            float distance2 = Vector3.Distance(playerTransform.position, crook2Transform.position);
            if (distance2 <= 2)
            {
                crook2_CurrentHP -= damageAmount;
                if (crook2_CurrentHP <= 0)
                {
                    Destroy(crook2);
                    crook2Transform = null;
                }

                else
                {
                    Debug.Log("Can seviyesi: " + crook2_CurrentHP);
                }
            }
        }
    }

}


/*
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(bowText.bowAktif == true && swordText.swordAktif == false && arrowText.arrowAktif == false)
            {
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

*/




