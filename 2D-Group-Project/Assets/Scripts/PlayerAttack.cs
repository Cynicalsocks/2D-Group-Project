﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private bool attacking = false;
    [SerializeField]
    private float attackTimer = 0;
    [SerializeField]
    private float attackCoolDown = 0.3f;

    public Collider2D attackTrigger;
    private Animator anim;

    //called at the start
    void Awake()
    {
        //Disable collider
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If key pressed and not attacking
        if (Input.GetKeyDown(KeyCode.Space) && !attacking)                           //original         if(Input.GetKeyDown(KeyCode.F) && !attacking)
        {
            attacking = true;
            attackTimer = attackCoolDown;

            FindObjectOfType<AudioManger>().Play("Cleaning", 0.1f); //check
            attackTrigger.enabled = true;
            Debug.Log("attacking");
        }

        if(attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        anim.SetBool("Attacking", attacking);
    }
}
