using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Pathfinding;
using UnityEngine;

public class StopEnnemy : MonoBehaviour
{
    AILerp AILerp;
    [SerializeField] Transform BidenTrans;
    Transform EnnemyTrans;
    Animator animator;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        EnnemyTrans = GetComponent<Transform>();
        AILerp = GetComponent<AILerp>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Vector2.Distance(BidenTrans.position, EnnemyTrans.position) < 1.5f)
        {
            AILerp.enabled = (false);
            animator.SetBool("attack", true);
        }
        else
        {
            AILerp.enabled = (true);
            animator.SetBool("attack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
