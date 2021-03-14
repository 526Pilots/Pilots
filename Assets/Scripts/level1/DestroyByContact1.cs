using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class DestroyByContact1 : MonoBehaviour
{
    private Rigidbody rb;
    //public GameObject player;
    private Color colorplayer;
    public GameObject bose;
    public GameObject explosion;

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
		// if(other.tag == "Boundary") 
		// {
		// 	return;
		// }
		if(other.tag == "Player"){
            ScoreScript.lives -= 1;
            AnalyticsEvent.Custom("lose_heart", new Dictionary<string, object>
            {
                { "lose_heart", Time.timeSinceLevelLoad }
            });
            if(ScoreScript.lives <= 0){
                Destroy(other.gameObject);
                Destroy(gameObject);   
                ScoreScript.lives = 3;
                ScoreScript.scoreValue = 0;
                SceneManager.LoadScene("Scenes/GameOver");                
            }
            else{
                Destroy(gameObject); 
            }     
        }
        else if(other.tag == "Bullet"){
            ScoreScript.scoreValue += 1;
            if (ScoreScript.scoreValue >= 5) {
                Instantiate(bose, new Vector3(0f, 0, 20f), transform.rotation);
            }
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);            
        }  
    }
}