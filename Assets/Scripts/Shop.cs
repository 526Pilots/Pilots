using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;



public class Shop : MonoBehaviour
{
    public static int HEALTH_PRICE = 3;
    public static int ATTACK_SPEED_PRICE = 3;
    public static int MOVE_SPEED_PRICE = 3;
    public static int INVULNERABLE_PRICE = 5;
    public static int FREEZE_ENEMY_PRICE = 5;
    public static int SLOW_DOWN_ENEMY_PRICE = 3;

    void Start()
    {   
        // Global.coinValues = 100;
        UpdateCoinValue();
    }

    void UpdateCoinValue() {
        GameObject.FindGameObjectWithTag("coinValues").GetComponent<Text>().text = Global.coinValues.ToString();
    }
    
    public void BuyHealth()
    {  
        if (Global.coinValues < HEALTH_PRICE) {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Coin is not enough.", "OK");
            return;
        }
        if (MallWorker.AddPlayerLife()) {
            Global.coinValues -= HEALTH_PRICE;
            UpdateCoinValue();
            UnityEditor.EditorUtility.DisplayDialog("Success", "Your current health is " + ScoreScript.lives.ToString(), "OK");
        } else {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Your health has achieved the max.", "OK");
        }
    }

    public void BuyMoveSpeed()
    {  
        // MallWorker.AddPlayerMoveSpeed();
        if (Global.coinValues < MOVE_SPEED_PRICE) {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Coin is not enough.", "OK");
            return;
        }
        if (MallWorker.AddPlayerMoveSpeed()) {
            Global.coinValues -= MOVE_SPEED_PRICE;
            UpdateCoinValue();
            UnityEditor.EditorUtility.DisplayDialog("Success", "Your current move speed is " + PlayerController.speed.ToString(), "OK");
        } else {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Your move speed has achieved the max.", "OK");
        }
    }

    public void BuyAttackSpeed()
    {  
        // MallWorker.AddPlayerFireRate();
        if (Global.coinValues < ATTACK_SPEED_PRICE) {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Coin is not enough.", "OK");
            return;
        }
        if (MallWorker.AddPlayerFireRate()) {
            Global.coinValues -= ATTACK_SPEED_PRICE;
            UpdateCoinValue();
            UnityEditor.EditorUtility.DisplayDialog("Success", "Your current attack speed is " + PlayerController.fireRate.ToString(), "OK");
        } else {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Your attack speed has achieved the max.", "OK");
        }
    }

    public void BuyInvulnerable()
    {  
        if (Global.coinValues < INVULNERABLE_PRICE) {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Coin is not enough.", "OK");
            return;
        }
        MallWorker.numOfInvulnerableBuff++;
        Global.coinValues -= INVULNERABLE_PRICE;
        UpdateCoinValue();
        UnityEditor.EditorUtility.DisplayDialog("Success", "You could press button \"J\" to remain Invulnerable for 5 seconds.", "OK");
    }

    public void BuyFreezeEnemy()
    {
        if (Global.coinValues < FREEZE_ENEMY_PRICE)
        {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Coin is not enough.", "OK");
            return;
        }
        MallWorker.numOfFreezeEnemyBuff++;
        Global.coinValues -= FREEZE_ENEMY_PRICE;
        UpdateCoinValue();
        UnityEditor.EditorUtility.DisplayDialog("Success", "You could press button \"K\" to freeze enemy for 5 seconds.", "OK");
    }

    public void BuySlowDownEnemy()
    {
        if (Global.coinValues < SLOW_DOWN_ENEMY_PRICE)
        {
            UnityEditor.EditorUtility.DisplayDialog("Failed", "Coin is not enough.", "OK");
            return;
        }
        MallWorker.numOfSlowDownEnemyBuff++;
        Global.coinValues -= SLOW_DOWN_ENEMY_PRICE;
        UpdateCoinValue();
        UnityEditor.EditorUtility.DisplayDialog("Success", "You could press button \"L\" to slow down enemy for 5 seconds.", "OK");
    }

    public void back() {
        SceneManager.LoadScene(sceneManager.lastSceneIndex);
    }
}

