﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]  GameObject playerAttackZone;
   [SerializeField] Animator animator;
    [SerializeField] int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerAttackZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerAttackZone.tag = "Attack";
        //Debug.Log("attack tag" + playerAttackZone.gameObject.tag);
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attacking");
        }


    }

    public void EnableAttackZone()
    {
        playerAttackZone.SetActive(true); 
    }
    
    public void DiasbleAttack()
    {
        playerAttackZone.SetActive(false);
    }

    public int  GiveDamage()
    {
        return attackDamage;
    }
}
