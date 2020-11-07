using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidenMove : MonoBehaviour
{
    
    Rigidbody2D bidenBody;
    Transform bidenPos;
    Vector2 bidenDirection;
    [SerializeField] float speed;
    
    void Start()
    {
        bidenBody = GetComponent<Rigidbody2D>();
        bidenPos = GetComponent<Transform>();
    }

    void Update()
    {
        bidenDirection = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        bidenBody.velocity = bidenDirection;
        bidenPos.rotation.z = 0;
    }
}
