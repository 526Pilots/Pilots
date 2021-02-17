using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public GameObject player;
    private Transform playerTran;
    public float attackrange;
    public float movespeed;
    private float CreatTime = 15f;

    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;
    private Vector3 move;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButton("Fire1") && Time.time > nextFire)
        // {
        //     nextFire = Time.time + fireRate;
        //     Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        // }
    }

    void FixedUpdate()
    {

        CreatTime -= Time.deltaTime;
        if (CreatTime<=0)    //如果倒计时为0 的时候
        {  
            //CreatTime = Random.Range(3, 10);
            CreatTime = 2f;
            Vector3 pos = new Vector3(Random.Range(-24f, 24f), 0, Random.Range(-15f,15f));
            Rigidbody clone = Instantiate(rb, pos, Quaternion.identity);
            playerTran = GameObject.FindGameObjectWithTag("Player").transform;
            //move = new Vector3(player.transform.position.x - clone.transform.position.x, 0, player.transform.position.z - clone.transform.position.z);
            move = new Vector3(playerTran.position.x - clone.transform.position.x, 0, playerTran.position.z - clone.transform.position.z);
            Vector3  V3 =  move .normalized;
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
            clone.transform.eulerAngles = new Vector3 (90, 0, (y));
            clone.velocity = V3 * movespeed;
        }

    }
}
