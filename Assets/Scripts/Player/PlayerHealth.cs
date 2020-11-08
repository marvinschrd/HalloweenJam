using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int health;
    Animator animator;
    Vector2 startingPosition;
    Scene currentScene;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startingPosition = transform.position;
        //currentScene = SceneManager.GetActiveScene();
        health = maxHealth;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("dead");
            body.bodyType = RigidbodyType2D.Static;
            //scenemanager.loadscene(currentscene.name);
            ActiveDeath();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            health = 0;
        }
    }

    public void ActiveDeath()
    {
        
        animator.SetTrigger("dead");
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
