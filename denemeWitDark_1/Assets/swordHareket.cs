using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class swordHareket : MonoBehaviour
{
    public Animator swordSolVurus;
    public Animator swordSagVurus;
    public Animator swordLastVurus;
    public static int i;

    //private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 48f;
    private float dashingTime = 1.5f;
    private float dashingAngle = 0;

    public static Rigidbody2D rb;

    [SerializeField] private TrailRenderer tr;
    void Start()
    {
        swordSolVurus = GetComponent<Animator>();
        swordSagVurus = GetComponent<Animator>();
        swordLastVurus = GetComponent<Animator>();
        i = 0;

    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (swordText.swordAktif == true)
            {
                if (i == 0)
                {
                    swordSolVurus.Play("swordAnimation2");
                    i += 1;
                }
                else if (i == 1)
                {
                    swordSagVurus.Play("swordAnimation3");
                    i += 1;
                }
                else if (i == 2)
                {
                    StartCoroutine(Dash());
                    swordLastVurus.Play("swordAnimation5");
                    i = 0;
                }
            }
        }
    }
    private IEnumerator Dash()
    {
        //canDash = false;
        isDashing = true;

        // PlayerMovement.rb.velocity = new Vector2(transform.localScale.z * dashingPower, 0f);

        Vector2 movementDirection = PlayerMovement.rb.velocity.normalized;
        float angle = Vector2.Angle(Vector2.up, movementDirection);
        if (movementDirection.y < 0f)
        {
            angle = 360f - angle;
        }

        float dashAngle = angle + (dashingAngle / 2f);
        Vector2 dashDirection = new Vector2(Mathf.Cos(dashAngle * Mathf.Deg2Rad), Mathf.Sin(dashAngle * Mathf.Deg2Rad));
        Vector2 dashVelocity = dashDirection * dashingPower;

        PlayerMovement.rb.velocity = dashVelocity;

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        //canDash = true;
    }
}