using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public int coinValues = Global.coinValues;
    Text coins;
    public static float speed = 8;
    public float tilt;
    public Boundary boundary;
    public Rigidbody rb;

    public GameObject shot;
    public Transform shotSpawn;
    public static float fireRate = 0.5f;

    private float nextFire;
    private float timerColor = 0f;
    private float timeSpentInvincible = 0f;
    // private float m_timer = 0f;
    public static float timeSpentInvincibleBuy = 0f;

    // private Color[] randomcolor = new Color[3];

    public int playerColor;
    public bool autoChangeColor;
    public bool isInvincible = false;
    public static bool isInvincibleBuy = false;

    public static bool isBuyInvunerable = false;

    // Skin/Model

    public Mesh[] meshList;

    // Material/Color
    public Material[] normal;
    public Material[] red;
    public Material[] yellow;
    public Material[] green;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // randomcolor[0] = Color.red;
        // randomcolor[1] = Color.green;
        // randomcolor[2] = Color.yellow;
        GameObject.FindGameObjectWithTag("coinValues").GetComponent<Text>().text = Global.coinValues.ToString();
        GameObject.FindGameObjectWithTag("iceValue").GetComponent<Text>().text = MallWorker.numOfFreezeEnemyBuff.ToString();
        GameObject.FindGameObjectWithTag("shieldValue").GetComponent<Text>().text = MallWorker.numOfInvulnerableBuff.ToString();
        GameObject.FindGameObjectWithTag("dmsValue").GetComponent<Text>().text = MallWorker.numOfSlowDownEnemyBuff.ToString();

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        // GetComponent<MeshRenderer>().materials = mr1;
        meshFilter.sharedMesh = meshList[Global.playerModel];
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        if (isBuyInvunerable == false)
        {
            isTnvincible();

            // m_timer += Time.deltaTime;
            // if (m_timer >= 3)
            // {
            //     this.GetComponent<MeshCollider>().enabled = true;
            //     this.GetComponent<CapsuleCollider>().enabled = true;
            //     m_timer = 0;
            // }
        }
        else
        {
            isTnvincibleBuy();
        }


    }

    void isTnvincible()
    {
        if (isInvincible)
        {
            //2
            timeSpentInvincible += Time.deltaTime;
            this.GetComponent<MeshCollider>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            //3
            if (timeSpentInvincible < 3f)
            {
                float remainder = timeSpentInvincible % 0.3f;
                GetComponent<Renderer>().enabled = remainder > 0.15f;
            }
            //4
            else
            {
                GetComponent<Renderer>().enabled = true;
                this.GetComponent<MeshCollider>().enabled = true;
                this.GetComponent<CapsuleCollider>().enabled = true;
                isInvincible = false;
            }
        }

    }

    void isTnvincibleBuy()
    {
        if (isInvincibleBuy)
        {
            //2
            timeSpentInvincibleBuy += Time.deltaTime;
            this.GetComponent<MeshCollider>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            //3
            if (timeSpentInvincibleBuy < 5f)
            {
                float remainderBuy = timeSpentInvincibleBuy % 0.3f;
                GetComponent<Renderer>().enabled = remainderBuy > 0.15f;
            }
            //4
            else
            {
                GetComponent<Renderer>().enabled = true;
                this.GetComponent<MeshCollider>().enabled = true;
                this.GetComponent<CapsuleCollider>().enabled = true;
                isInvincibleBuy = false;
                isBuyInvunerable = false;
            }
        }

    }

    void FixedUpdate()
    {
        timerColor -= Time.deltaTime;
        if (timerColor <= 0 && autoChangeColor)
        {

            // rb.GetComponent<SpriteRenderer>().material.color = randomcolor[TargetEnemyColorIndictor.color - 1];
            if (TargetEnemyColorIndictor.color == 1)
            {
                GetComponent<MeshRenderer>().materials = red;
            }
            else if (TargetEnemyColorIndictor.color == 2)
            {
                GetComponent<MeshRenderer>().materials = green;
            }
            else if (TargetEnemyColorIndictor.color == 3)
            {
                GetComponent<MeshRenderer>().materials = yellow;
            }
            else
            {
                GetComponent<MeshRenderer>().materials = normal;
            }
            timerColor = 2f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * moveVertical * speed * Time.fixedDeltaTime, Space.World);
        transform.Translate(Vector3.right * moveHorizontal * speed * Time.fixedDeltaTime, Space.World);

        Vector3 mousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(new Vector3(mousePo.x, 0, mousePo.z));
        // transform.Rotate(90, 0, 0);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Buff")
        {
            MallWorker.AddPlayerFireRate();
            Destroy(other.gameObject);

        }
        else if (other.tag == "Boundary")
        {
            restart();

        }
        else if (other.tag == "coin")
        {
            coinValues++;
            coins = GameObject.FindGameObjectWithTag("coinValues").GetComponent<Text>();
            coins.text = coinValues.ToString();
            Global.coinValues = coinValues;
            Destroy(other.gameObject);

        }
    }

    public void restart()
    {
        Vector3 player_position = this.transform.position;
        player_position.x = 0;
        player_position.y = 0;
        player_position.z = 0;
        this.GetComponent<Transform>().position = player_position;
        isInvincible = true;
        timeSpentInvincible = 0f;
        ScoreScript.lives -= 1;


    }
}