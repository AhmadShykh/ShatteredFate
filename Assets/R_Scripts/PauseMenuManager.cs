using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenuCanvas;

    public GameObject GameOverMenu;

    public PlayerHealth playerHealthScript;

    static int escapeCount=0;

    private bool allowRetry=false;


    void Start()
    {
        PauseMenuCanvas.SetActive(false);
        GameOverMenu.SetActive(false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(escapeCount==0)
            {
                escapeCount=1;
                PauseMenuCanvas.SetActive(true);
                Time.timeScale=0;
                if(Input.GetKeyDown(KeyCode.M))
                {
                    //Main Menu Scene Load 
                    SceneManager.LoadScene(0);
                }
            }
            else if(escapeCount==1)
            {
                escapeCount=0;
                PauseMenuCanvas.SetActive(false);
                Time.timeScale=1;

            }
            
        }

        if(playerHealthScript.isAlreadDead)
        {
            GameOverMenu.SetActive(true);
            allowRetry=true;

            if(allowRetry)
            {
                if(Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else if(Input.GetKeyDown(KeyCode.M))
                {
                    //Main Menu Scene Load 
                    SceneManager.LoadScene(0);
                }
            }

        }


    }
}
