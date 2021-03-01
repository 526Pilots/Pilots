using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float timerOne = 1f;
    private float timeOne = 1.0f;
    private float timerWave = 0f;
    private float timeWave = 10.0f;
    private int countPerWave = 0;
    private float CreatTime = 3f;
    public GameObject[] enemyList;
    private GameObject spawnPerfab;
    // public GameObject enemy1;
    // public GameObject enemy2;
    // public GameObject enemy3;
    // Start is called before the first frame update
    void Start()
    {
        // enemyList = new GameObject[3];
        // enemyList[0] = enemy1;
        // enemyList[1] = enemy2;
        // enemyList[2] = enemy3;
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
            //int index = Random.Range(0, 3);
            spawnPerfab = enemyList[Random.Range(0, 3)];
            if(timerWave < timeWave && countPerWave != 5) {
                timerOne += Time.deltaTime;
                if(timerOne > timeOne && ScoreScript.lives > 0) {
                    
                    Instantiate (spawnPerfab, new Vector3(Random.Range(-24f, 24f), 0, Random.Range(-15f,15f)), spawnPerfab.transform.rotation);
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