using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallWorker : MonoBehaviour
{
    public static int fireRateUpgrateLeftTimes = 5;
    public static int moveSpeedUpgrateLeftTimes = 5;

    public static int numOfFreezeEnemyBuff = 1;
    public static int numOfSlowDownEnemyBuff = 1;
    public static int numOfInvulnerableBuff = 1;
    public static float enemySpecialSpeedTimeLeft = 0f;

    public static float ENEMY_FREEZEN_MOVE_SPEED = 0.001f;
    public static float ENEMY_SLOWN_DOWN_SPEED = 2;

    // private bool isInvincible = false;
    // private float timeSpentInvincible = 0f;
    // private float m_timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpecialSpeedStatus();
        GetBuffBottonInput();
    }

    void UpdateSpecialSpeedStatus()
    {
        if (enemySpecialSpeedTimeLeft <= 0f)
        {
            enemySpecialSpeedTimeLeft = 0f;
            EnemyController.movespeed = EnemyController.ENEMY_NORMAL_MOVE_SPEED;
            EnemyController1.movespeed = EnemyController1.ENEMY_NORMAL_SPEED;
        }
        else
        {
            enemySpecialSpeedTimeLeft -= Time.deltaTime;
        }
    }

    void GetBuffBottonInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Invulnerable();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            FreezeEnemy();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SlowDownEnemy();
        }
    }

    public static bool AddPlayerFireRate()
    {
        if (fireRateUpgrateLeftTimes <= 0) {
            return false;
        }   
        PlayerController.fireRate = (float)(PlayerController.fireRate*0.5);
        fireRateUpgrateLeftTimes--;
        return true;
    }

    public static bool AddPlayerMoveSpeed()
    {
        if (moveSpeedUpgrateLeftTimes <= 0) {
            return false;
        }
        PlayerController.speed += 10;
        moveSpeedUpgrateLeftTimes--;
        return true;
    }

    public static bool AddPlayerLife()
    {
        if (ScoreScript.lives >= ScoreScript.MAX_LIVES) {
            return false;
        }
        ScoreScript.lives++;
        return true;
    }

    public static bool Invulnerable()
    {
        if (numOfInvulnerableBuff <= 0)
        {
            return false;
        }
        numOfInvulnerableBuff--;
        PlayerController.isBuyInvunerable = true;
        PlayerController.isInvincibleBuy = true;
        PlayerController.timeSpentInvincibleBuy = 0f;
        return true;
    }

    public static bool FreezeEnemy()
    {
        if (numOfFreezeEnemyBuff <= 0)
        {
            return false;
        }
        numOfFreezeEnemyBuff--;
        enemySpecialSpeedTimeLeft = 5f;
        EnemyController.movespeed = ENEMY_FREEZEN_MOVE_SPEED;
        EnemyController1.movespeed = ENEMY_FREEZEN_MOVE_SPEED;
        return true;
    }

    public static bool SlowDownEnemy()
    {
        if (numOfSlowDownEnemyBuff <= 0)
        {
            return false;
        }
        numOfSlowDownEnemyBuff--;
        enemySpecialSpeedTimeLeft = 5f;
        EnemyController.movespeed = ENEMY_SLOWN_DOWN_SPEED;
        EnemyController1.movespeed = ENEMY_SLOWN_DOWN_SPEED;
        return true;
    }
}
