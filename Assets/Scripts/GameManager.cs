using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void Restart(){
        ScoreScript.lives = ScoreScript.MAX_LIVES;
        ScoreScript.scoreValue = 0;
        if(sceneManager.lastSceneName!=null){
            SceneManager.LoadScene(sceneManager.lastSceneIndex);
        }else{
            SceneManager.LoadScene(0);
        }
    }
    public static void Quit(){
        Application.Quit();
    }
}
