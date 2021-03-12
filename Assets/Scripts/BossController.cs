using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{

	public GameObject player;
    private Transform playerTran;
    public float attackrange;
    public float movespeed;
    public static int bulletDamage = 5;
    //private float CreatTime = 15f;

    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;
    private SpriteRenderer renderReference;
    private Vector3 move;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    public int shotNumPerWave;
    private int shotNum;
    private int status; // -1: stop shooting; 1: keep shoting
    public static int MAX_HEALTH = 10;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderReference = GetComponent<SpriteRenderer>();
        health = MAX_HEALTH;
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

    public void Awake() {
        Invoke("Launch", 5);
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
	    } else if(other.tag == "Player"){
            reduceHealth(bulletDamage);
            ScoreScript.lives -= 1;
            if(ScoreScript.lives <= 0){
                Destroy(other.gameObject);             
            }
        } else if(other.tag == "Bullet"){
            Destroy(other.gameObject); 
            reduceHealth(bulletDamage);
        }
        if (health <= 0) {
            Destroy(gameObject); 
            SwitchToNextScene();
        }
	}

    void SwitchToNextScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void reduceHealth(int damage) {
        health = health - damage;
        renderReference.color = new Color(1, 1.0f * health / MAX_HEALTH, 1, 1);
        // renderReference.color = new Color(1, 0.1f, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            if (shotNum == shotNumPerWave || status == -1) {
                status = -1;
                shotNum--;
                if (shotNum == 0) {
                    status = 1;
                }
            } else {

                // Instantiate(shot,
                // rb.position, rb.rotation);
                shotNum++;
            }
            nextFire = Time.time + fireRate;
        }
    }

    void FixedUpdate()
    {
    }
}
