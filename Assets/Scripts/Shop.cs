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

    void Start()
    {   
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

    public void backToMain() {
        SceneManager.LoadScene(0);
    }
}

