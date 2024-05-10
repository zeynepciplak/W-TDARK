using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHareket : MonoBehaviour
{
    public Animator swordSolVurus;
    public Animator swordSagVurus;
    public static int i;
    void Start()
    {
        swordSolVurus = GetComponent<Animator>();
        i = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (i == 0)
            {
                swordSolVurus.Play("swordAnimation2");
                i += 1;
            }
            else if (i == 1)
            {
                swordSagVurus.Play("swordAnimation3");
                i = 0;
            }
            /*
            else if (i == 2)
            {

                i == 0;
            }
            */
            
        }
    }
}
