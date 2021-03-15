using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int lives = 3;
    public Text score;
    // Start is called before the first frame update
    private Slider slider;

    // Update is called once per frame
    void Update()
    {   
        // GameObject TargetEnemyColorIndictor = GameObject.FindWithTag("TargetEnemyColorIndictor");
        // int color = TargetEnemyColorIndictor.GetComponent<TargetEnemyColorIndictor>().color;

        // int color = TargetEnemyColorIndictor.color;
        // string colorText = "Undefined";
        // if (color == 1) {
        //     colorText = "Red";
        // } else if (color == 2) {
        //     colorText = "Green";
        // } else if (color == 3) {
        //     colorText = "Yellow";
        // }
        // score.text = "Score: " + scoreValue + "  Lives: " + lives +"  Target Color: " +colorText;
        
        score.text = "Score: " + scoreValue + "  Lives: " + lives;

        if(lives <= 0){
            lives = 3;
            scoreValue = 0;
            
            var currentScene = SceneManager.GetActiveScene();
            var currentSceneName = currentScene.name;
            sceneManager.lastSceneName = currentSceneName;
            sceneManager.lastSceneIndex = currentScene.buildIndex;

            AnalyticsEvent.Custom("Game Over", new Dictionary<string, object>
            {
                {"time for " + currentSceneName, Time.timeSinceLevelLoad },
                {"score for " + currentSceneName, scoreValue},
                {"number of lost health for "+currentSceneName, 3}
            });

            SceneManager.LoadScene("Scenes/GameOver");  
        }
        GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<Slider>().value = ScoreScript.scoreValue;
        GameObject.FindGameObjectWithTag("LifeBar").GetComponent<Slider>().value = ScoreScript.lives;
    }
}

