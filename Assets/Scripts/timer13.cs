using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer13 : MonoBehaviour
{
    float timeRemaining = 13;
    bool timerIsRunning = false;
    [SerializeField] TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
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
                Debug.Log("vous avez perdu");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        textMesh.text = timeRemaining.ToString();
    }
}