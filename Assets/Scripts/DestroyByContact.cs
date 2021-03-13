using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
    private Rigidbody rb;
    //public GameObject player;
    private Color colorplayer;

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
            if (TargetEnemyColorIndictor.color == 1 && rb.tag == "EnemyR" ||
                TargetEnemyColorIndictor.color == 2 && rb.tag == "EnemyG" ||
                TargetEnemyColorIndictor.color == 3 && rb.tag == "EnemyY") {
                ScoreScript.scoreValue += 1;
            } else if (ScoreScript.scoreValue > 0) {
                ScoreScript.scoreValue -= 1;
            }
            
            Destroy(other.gameObject);
            Destroy(gameObject);            
        }  
    }
}


