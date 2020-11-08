using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class FlyingEnnemiesDetection : MonoBehaviour
{
    AILerp aiLerp;
    //SpriteRenderer spriteRenderer;
    //[SerializeField] Transform playerTrans;
    //Transform ennemyTrans;

    void Start()
    {
        aiLerp = GetComponent<AILerp>();
        //ennemyTrans = GetComponent<Transform>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            aiLerp.enabled = (true);
        }
        
        
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            aiLerp.enabled = (false);
        }
    }
}
