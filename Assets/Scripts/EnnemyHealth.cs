using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            // animator.SetTrigger("Death");
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Attack")
        {
            PlayerAttack playerAttack = collision.gameObject.GetComponent<PlayerAttack>();
            health -= playerAttack.GiveDamage();
        }
    }

}
