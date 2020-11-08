using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer13 : MonoBehaviour
{
    [SerializeField] GameObject loosetext;
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
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //loosetext.SetActive(true);
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

    public float GiveTimer()
    {
        return timeRemaining;
    }
}