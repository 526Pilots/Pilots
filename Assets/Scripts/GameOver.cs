using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameOver : MonoBehaviour
{
    public void RestartGame(){
        AnalyticsEvent.Custom("Quit at level " + sceneManager.lastSceneName, new Dictionary<string, object>{});
        GameManager.Restart();
    }
    public void QuitGame(){
        GameManager.Quit();
    }
}
