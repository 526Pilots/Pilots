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
        SceneManager.LoadScene("Scenes/Help");
    }

    public void goToShop()
    {  
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
        sceneManager.lastSceneName = currentSceneName;
        sceneManager.lastSceneIndex = currentScene.buildIndex;
        SceneManager.LoadScene("Scenes/Shop");
    }
}
