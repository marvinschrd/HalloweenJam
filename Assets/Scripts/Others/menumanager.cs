using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    [SerializeField] GameObject mygameobject;
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void credits()
    {
        mygameobject.SetActive(true);
    }
    
    public void CloseCredits()
    {
        mygameobject.SetActive(false);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
