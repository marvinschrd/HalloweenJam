using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    Animator animator;
    GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManagerScript>();
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
        gameManager.EnnemieKilled();
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    //    Debug.Log("attacked");
    //    Debug.Log(collision.gameObject.tag);
    //    if(collision.gameObject.tag == "Attack")
    //    {
    //        Debug.Log("HIT");
    //        PlayerAttack playerAttack = collision.gameObject.GetComponent<PlayerAttack>();
    //        health -= playerAttack.GiveDamage();
    //    }
    }

}
