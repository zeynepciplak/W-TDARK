using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class bowHareket : MonoBehaviour
{
    public Animator bowVurus;
    public static int i;
    public static Rigidbody2D rb;

    //[SerializeField] private TrailRenderer tr;
    void Start()
    {
        bowVurus = GetComponent<Animator>();
        i = 0;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bowText.bowAktif == true)
            {
                bowVurus.Play("arrowAnimation");
            }
        }
    }

}