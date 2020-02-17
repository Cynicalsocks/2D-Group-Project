﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;

    private float attackTimer = 0;

    private float attackCoolDown = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If key pressed and not attacking
        if(Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTimer = attackCoolDown;

            attackTrigger.enabled = true;
            Debug.Log("attack");
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
