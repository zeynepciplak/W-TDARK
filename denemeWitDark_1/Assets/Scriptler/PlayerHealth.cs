using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHP;
    public int playerCurrentHP;
    public GameObject playerDeathModel;
    

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    public swordText swordAktif;
    
    void Start()
    {
        playerCurrentHP = playerMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //if(swordAktif == true) { 
            if (timeBtwAttack <=0)
            {
                // then you can attack
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for(int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    }
                timeBtwAttack = startTimeBtwAttack;
            }
            
            else {
                    timeBtwAttack -= Time.deltaTime;
                }
            }
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}



