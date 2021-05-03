using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameOver : MonoBehaviour
{
    public void RestartGame(){
        AnalyticsEvent.Custom("Restart at " + sceneManager.lastSceneName, new Dictionary<string, object>{});
        GameManager.Restart();
    }
    public void QuitGame(){
        AnalyticsEvent.Custom("Quit at " + sceneManager.lastSceneName, new Dictionary<string, object>{});
        GameManager.Quit();
    }
    public void ReturnToMenu() {
        GameManager.ReturnToMenu();
    }
}
