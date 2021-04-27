using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void Start()
    {   
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
        sceneManager.lastSceneName = currentSceneName;
        sceneManager.lastSceneIndex = currentScene.buildIndex;
    }
    
    public void TaskOnClick()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
        
    public void goToShop()
    {  
        SceneManager.LoadScene("Scenes/Shop");
    }

    public void backToMain() {
        SceneManager.LoadScene(0);
    }
}

