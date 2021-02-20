using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public float tumble;
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
            }
            else{
                Destroy(gameObject); 
            }     
        }
        else if(other.tag != "EBullet"){
            ScoreScript.scoreValue += 1;
            Destroy(other.gameObject);
            Destroy(gameObject);            
        }  
    }
}


