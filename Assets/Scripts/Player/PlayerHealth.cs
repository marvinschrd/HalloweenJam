using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int health;

    Vector2 startingPosition;
    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        currentScene = SceneManager.GetActiveScene();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            SceneManager.LoadScene(currentScene.name);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            health = 0;
        }
    }
}
