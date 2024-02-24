using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioClip clickSound;

    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;

    public GameObject InstructionsCanvas;

    void Start()
    {
        MainMenuCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
        InstructionsCanvas.SetActive(false);

    }



    public void onClickStart()
    {
        SoundManager.instance.playSoundEffect(clickSound);
        SceneManager.LoadScene("LEVEL1 1");
    }

    public void onClickCredits()
    {
        SoundManager.instance.playSoundEffect(clickSound);
        MainMenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
        

    }

    public void onClickInstructions()
    {
        SoundManager.instance.playSoundEffect(clickSound);

        MainMenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        InstructionsCanvas.SetActive(true);

    }

    public void onClickExit()
    {
        SoundManager.instance.playSoundEffect(clickSound);
        Application.Quit();
    }


    public void onClickCreditsBack()
    {
        SoundManager.instance.playSoundEffect(clickSound);
        MainMenuCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
        InstructionsCanvas.SetActive(false);


    }

}
