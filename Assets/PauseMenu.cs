using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool help = false;
    public GameObject PauseMenuUI; 
    public GameObject HelpMenuUI; 
    // Update is called once per frame
    public void ClickPause()
    {
        if(GameIsPaused){
            Resume();
        }else{
            Pause();
        }
    }
    public void ClickHelp(){
        if(help){
            HelpMenuUI.SetActive(false);
            help = false;
        }else{
            HelpMenuUI.SetActive(true);
            help = true;
        }
    }

    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu(){
        SceneManager.LoadScene(0);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
