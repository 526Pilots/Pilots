using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame(){
        GameManager.Restart();
    }
    public void QuitGame(){
        AnalyticsEvent.Custom("Quit at level " + sceneManager.lastSceneName, new Dictionary<string, object>{});
        GameManager.Quit();
    }
}
