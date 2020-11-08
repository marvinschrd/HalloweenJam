using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int damage = 10;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<EnnemyHealth>() != null)
        {

            Debug.Log("HIT");
            EnnemyHealth Health = collision.gameObject.GetComponent<EnnemyHealth>();
            Health.TakeDamage(damage);
        }
    }
}
