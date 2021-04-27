using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallWorker : MonoBehaviour
{
    public static int fireRateUpgrateLeftTimes = 5;
    public static int moveSpeedUpgrateLeftTimes = 5;
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
        PlayerController.isBuyInvunerable = true;
        PlayerController.isInvincibleBuy = true;
        PlayerController.timeSpentInvincibleBuy = 0f;
        return true;
    }
}
