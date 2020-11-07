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
    void Start()
    {
        EnnemyTrans = GetComponent<Transform>();
        AILerp = GetComponent<AILerp>();
    }

    private void Update()
    {
        if (Vector2.Distance(BidenTrans.position, EnnemyTrans.position) < 1)
        {
            AILerp.enabled = (false);
        }
        else
        {
            AILerp.enabled = (true);
        }
    }
}
