using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class DestroyByContact2 : MonoBehaviour
{
    private Rigidbody rb;
    //public GameObject player;
    private Color colorplayer;
    public GameObject bose;
    public GameObject explosion;
    private int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // void FixedUpdate()
    // {
    //     colorplayer = player.GetComponent<SpriteRenderer>().sharedMaterial.color;
    //     print(colorplayer);
    // }

    //当其他碰撞器进入当前GameObject的触发器时，销毁该碰撞器对应的游戏对象，同时销毁该GameObject
    void OnTriggerEnter(Collider other)
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
		// if(other.tag == "Boundary") 
		// {
		// 	return;
		// }
		if(other.tag == "Player"){
            ScoreScript.lives -= 1;
            // AnalyticsEvent.Custom("lose_heart", new Dictionary<string, object>
            // {
            //     { "lose_heart", Time.timeSinceLevelLoad }
            // });
            if(ScoreScript.lives <= 0){
                Destroy(other.gameObject);
                Destroy(gameObject);   
                ScoreScript.lives = ScoreScript.MAX_LIVES;
                ScoreScript.scoreValue = 0;
                sceneManager.lastSceneName = currentSceneName;
                sceneManager.lastSceneIndex = currentScene.buildIndex;
                SceneManager.LoadScene("Scenes/GameOver");                
            }
            else{
                Destroy(gameObject); 
            }     
        }
        else if(other.tag == "Bullet"){
            if (TargetEnemyColorIndictor.color == 1 && rb.tag == "EnemyR" ||
                TargetEnemyColorIndictor.color == 2 && rb.tag == "EnemyG" ||
                TargetEnemyColorIndictor.color == 3 && rb.tag == "EnemyY") {
                ScoreScript.scoreValue += 1;
                if (ScoreScript.scoreValue == 5 && flag == 0) {
                    flag = 1;
                    AnalyticsEvent.Custom("time for "+ currentSceneName + " to meet boss", new Dictionary<string, object>
                    {
                        {"time for " + currentSceneName + " to meet boss", Time.timeSinceLevelLoad }
                    });
                    Instantiate(bose, new Vector3(0f, 0, 20f), transform.rotation);
                }
            } else if (ScoreScript.scoreValue > 0) {
                ScoreScript.scoreValue -= 1;
            }
            
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);            
        }  
    }
}


