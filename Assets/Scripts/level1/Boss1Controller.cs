using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Boss1Controller : MonoBehaviour
{

	public GameObject player;
    public GameObject Blood;
    private Transform playerTran;
    public float attackrange;
    public float movespeed;
    public static int bulletDamage = 1;
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

    // color change
    private float timerColor = 0f;
    private Color[] randomcolor = new Color[3];

    public int shotNumPerWave;
    private int shotNum;
    private int status; // -1: stop shooting; 1: keep shoting
    public static int MAX_HEALTH = 10;
    public int health;

    private SpriteRenderer render;
    private Slider slider;


    // Start is called before the first frame update
    void Start()
    {

        
        rb = GetComponent<Rigidbody>();
        randomcolor[0] = Color.yellow;
        randomcolor[1] = Color.green;
        randomcolor[2] = Color.green;

        renderReference = GetComponent<SpriteRenderer>();

        health = MAX_HEALTH;
        player = GameObject.FindGameObjectWithTag("Player");
        Blood  = GameObject.FindGameObjectWithTag("Blood");

        slider =  Blood.GetComponent<Slider>();
        if (player == null) {
            GameOver();
        }
        if (Blood == null) {
            GameOver();
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
            if(playerTran!=null){
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
	    } else if(other.tag == "Player"){
            reduceHealth(bulletDamage);
            ScoreScript.lives -= 1;
            if(ScoreScript.lives <= 0){
                Destroy(other.gameObject);             
            }
        } else if(other.tag == "Bullet"){
            if (true)
            {
                
            }
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

    void GameOver(){
        ScoreScript.lives = 3;
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("Scenes/GameOver");
    }

    void reduceHealth(int damage) {
        health = health - damage;
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
                shotNum++;
            }
            nextFire = Time.time + fireRate;
        }
        if(GameObject.FindGameObjectWithTag("Player") == null){
            GameOver();
        }


    }

    void FixedUpdate()
    {
        slider.value = 10 - health;

    }
}
