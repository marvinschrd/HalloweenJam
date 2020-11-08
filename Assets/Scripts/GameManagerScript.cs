using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    PlayerHealth playerHealth;
    timer13 timer;
    float timerCount;

    [SerializeField] GameObject blackScreen;
   [SerializeField] GameObject [] ennemies;

    int numberOfEnnemies;
    bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        timer = FindObjectOfType<timer13>();
        numberOfEnnemies = ennemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        timerCount = timer.GiveTimer();
        if(timerCount<=0&&!won)
        {
            playerHealth.ActiveDeath();
            timer.SetText();
            blackScreen.SetActive(true);
        }

        if(numberOfEnnemies==0)
        {
            timer.SetWinText();
            won = true;
        }
    }


    public void EnnemieKilled()
    {
        numberOfEnnemies--;
        timer.AddTime();
    }
    
}
