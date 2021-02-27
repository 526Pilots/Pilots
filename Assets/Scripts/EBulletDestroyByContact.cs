using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletDestroyByContact : MonoBehaviour
{
    //当其他碰撞器进入当前GameObject的触发器时，销毁该碰撞器对应的游戏对象，同时销毁该GameObject
    void OnTriggerEnter(Collider other)
    {
		if(other.tag == "Player"){
            ScoreScript.lives -= 1;
            if(ScoreScript.lives <= 0){
                Destroy(other.gameObject);
                Destroy(gameObject);                  
            }
            else{
                Destroy(gameObject); 
            }     
        }
		else if(other.tag == "Boundary") {
			Destroy(gameObject);
		}
		else if(other.tag == "Buff") {
			
		}
        else if(other.tag != "EnemyR" && other.tag != "EnemyG" && other.tag != "EnemyY"){
            Destroy(other.gameObject);
            Destroy(gameObject);            
        }
		
    }
}


