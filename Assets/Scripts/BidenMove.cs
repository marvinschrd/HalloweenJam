using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidenMove : MonoBehaviour
{
    
    Rigidbody2D bidenBody;
    Vector2 bidenDirection;
    [SerializeField] float speed;
    
    void Start()
    {
        bidenBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bidenDirection = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        bidenBody.velocity = bidenDirection;
    }
}
