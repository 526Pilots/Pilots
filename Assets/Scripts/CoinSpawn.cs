using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private float timerOne = 0f;
    private float timeOne = 3.0f;
    private float timerWave = 0f;
    private float timeWave = 15.0f;
    private int countPerWave = 0;
    private float CreatTime = 3f;
    public GameObject coin;
    // public GameObject enemy1;
    // public GameObject enemy2;
    // public GameObject enemy3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreatTime -= Time.deltaTime;
        if (CreatTime<=0)    //如果倒计时为0 的时候
        {  
            //CreatTime = Random.Range(3, 10);
            CreatTime = 0f;
            timerWave += Time.deltaTime;
            if(timerWave < timeWave && countPerWave != 2) {
                timerOne += Time.deltaTime;
                if(timerOne > timeOne && ScoreScript.lives > 0) {
                    Instantiate (coin, new Vector3(Random.Range(-20, 20), 0f, Random.Range(-20, 20)), coin.transform.rotation);
                    countPerWave++;
                    timerOne -= timeOne;
                }
            }
            if (timerWave >= timeWave) {
                timerWave -= timeWave;
                countPerWave = 0;
            }
        }
    }
}
