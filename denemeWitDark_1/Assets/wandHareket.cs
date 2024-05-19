using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class wandHareket : MonoBehaviour
{
    public Animator wandVurus;
    public static int i;
    public static Rigidbody2D rb;

    [SerializeField] private TrailRenderer tr;
    void Start()
    {
        wandVurus = GetComponent<Animator>();
        i = 0;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            wandVurus.Play("sparkAnimation");
        }
    }
    
}