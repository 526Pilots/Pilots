using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        GameManager.Play();
    }
    public void QuitGame(){
        GameManager.Quit();
    }
    public void goToHelp() {
        SceneManager.LoadScene(1);
    }
}
