using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class DestroyByContact3 : MonoBehaviour
{
    private Rigidbody rb;
    //public GameObject player;
    private Color colorplayer;
    public GameObject explosion;
    private char cr;

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
        cr = rb.tag.ToCharArray()[0];
        // if (WordController.GetCurChar() == rb.tag) {
        //     tag = true;
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
                //WordController.CheckCharacter(cr);
            }     
        }
        else if(other.tag == "Bullet"){
            ScoreScript.scoreValue += 1;
            WordController.CheckCharacter(cr);
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);            
        }  
    }

}