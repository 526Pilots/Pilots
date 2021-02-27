using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffControl : MonoBehaviour
{
	
	public GameObject player;
	private Transform playerTran;
	public float attackrange;
	public float movespeed;
	//private float CreatTime = 15f;
	
	public float tilt;
	public Boundary boundary;
	private Rigidbody rb;
	private Vector3 move;

	
	// Start is called before the first frame update
	void Start()
	{
	    rb = GetComponent<Rigidbody>();
	    player = GameObject.FindGameObjectWithTag("Player");
	    if (player == null) {
	        return;
	    }
	    playerTran = player.transform;
	    move = new Vector3(playerTran.position.x - this.transform.position.x, 0, playerTran.position.z - this.transform.position.z);
	    Vector3  V3 =  move.normalized;
	    //角度
	    float y;
	    if ((V3).x >= 0 && (V3).z >= 0) {//左下
	        y = Vector3.Angle (Vector3.right, V3)-90;
	    }
	    else if ((V3).x >= 0 && (V3).z < 0) {//左上
	        y = -Vector3.Angle (Vector3.right, V3)-90;
	    }
	    else if ((V3).x < 0 && (V3).z >= 0) {//右下
	        y = Vector3.Angle (Vector3.right, V3)-90;
	    }
	    else{//右上
	        y = -Vector3.Angle (Vector3.right, V3)-90;
	    }
	    rb.transform.eulerAngles = new Vector3 (90, 0, (y));
	    rb.velocity = V3 * movespeed;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Boundary"){
			move = new Vector3(playerTran.position.x - this.transform.position.x, 0, playerTran.position.z - this.transform.position.z);
			Vector3  V3 =  move.normalized;
			float y;
			if ((V3).x >= 0 && (V3).z >= 0) {//左下
			    y = Vector3.Angle (Vector3.right, V3)-90;
			}
			else if ((V3).x >= 0 && (V3).z < 0) {//左上
			    y = -Vector3.Angle (Vector3.right, V3)-90;
			}
			else if ((V3).x < 0 && (V3).z >= 0) {//右下
			    y = Vector3.Angle (Vector3.right, V3)-90;
			}
			else{//右上
			    y = -Vector3.Angle (Vector3.right, V3)-90;
			}
			rb.transform.eulerAngles = new Vector3 (90, 0, (y));
			rb.velocity = V3 * movespeed;
	    }
		
	}
	

    // Update is called once per frame
    void Update()
    {

    }
}
