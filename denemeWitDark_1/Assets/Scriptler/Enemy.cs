using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyCurrenthealth;
    public int enemyMaxhealth = 100;
    public int speed;
    void Start()
    {
        //enemyCurrenthealth = enemyMaxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCurrenthealth < 0)
        {
            Destroy(gameObject);
            Debug.Log("Düþman öldü!");
        }
    }

    public void TakeDamage(int damage)
    {
        enemyCurrenthealth -= damage;
        // Debug.Log("hasar alýndý.");
        Debug.Log(Convert.ToString(damage) + " hasar alýndý.");
        Debug.Log("Düþmanýn caný:" + Convert.ToString(enemyCurrenthealth));
    }

}
