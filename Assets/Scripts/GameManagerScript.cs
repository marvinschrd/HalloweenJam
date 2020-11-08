using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    PlayerHealth playerHealth;
    timer13 timer;
    float timerCount;

   [SerializeField] GameObject[] ennemies;
    [SerializeField] GameObject[] trapPlatforms;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        timer = FindObjectOfType<timer13>();
    }

    // Update is called once per frame
    void Update()
    {
        timerCount = timer.GiveTimer();
        if(timerCount<=0)
        {
            playerHealth.ActiveDeath();
            timer.SetText();
        }
    }

    
}
