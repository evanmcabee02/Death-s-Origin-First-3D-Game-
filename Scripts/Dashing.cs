using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("Refrences")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private PlayerMovement pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;


    [Header("Input")]
    public KeyCode dashKey = KeyCode.E;

    public Animator animator;
    public GameObject parti;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }
    private Vector3 delayedForceToApply;

    private void Update()
    {
        if (Input.GetKeyDown(dashKey))
        {

            Dash();
        }

        if (dashCdTimer > 0)
        {
            dashCdTimer -= Time.deltaTime;
        }
        else
        {
            if (parti.activeSelf)
            {
                parti.SetActive(false);
            }
        }

    }

    private void Dash()
    {
        if (dashCdTimer > 0) return; //cooldown active cannot dash
        else dashCdTimer = dashCd; //start the timer and execute dash function
        animator.SetTrigger("Dash");
        parti.SetActive(true);

        pm.dashing = true;

        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);
    }


    //wait before applying dash force
    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);

    }

    private void ResetDash()
    {
        pm.dashing = false;
    }
}

