using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer13 : MonoBehaviour
{
    [SerializeField] GameObject loosetext;
    [SerializeField] GameObject winText;
    float timeRemaining = 13.0f;
    bool timerIsRunning = false;
    [SerializeField] TextMeshProUGUI textMesh;
    GameManagerScript gameManager;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if(timeRemaining >= 13.0f)
            {
                timeRemaining = 13.0f;
            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                loosetext.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("vous avez perdu");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        textMesh.text = timeRemaining.ToString("F2");
    }

    public void SetText()
    {
        loosetext.SetActive(true);
    }
    public void SetWinText()
    {
        winText.SetActive(true);
    }
     public void AddTime()
    {
        timeRemaining += 3.0f;
    }

    public float GiveTimer()
    {
        return timeRemaining;
    }
}