using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3 : MonoBehaviour
{
    private float timerOne = 1f;
    private float timeOne = 1.0f;
    private float timerWave = 0f;
    private float timeWave = 10.0f;
    private int countPerWave = 0;
    private float CreatTime = 1.5f;
    public GameObject[] enemyList;
    private GameObject spawnPerfab;
    private Vector3[] v = new Vector3[8];
    private int flag = 0;
    // public GameObject enemy1;
    // public GameObject enemy2;
    // public GameObject enemy3;
    // Start is called before the first frame update
    void Start()
    {
        v[0] = new Vector3(-20f, 0f, 20f);
        v[1] = new Vector3(-20f, 0f, 0f);
        v[2] = new Vector3(-20f, 0f, -20f);
        v[3] = new Vector3(0f, 0f, 20f);
        v[4] = new Vector3(0f, 0f, -20f);
        v[5] = new Vector3(20f, 0f, 20f);
        v[6] = new Vector3(20f, 0f, 0f);
        v[7] = new Vector3(20f, 0f, -20f);
        // enemyList = new GameObject[3];
        // enemyList[0] = enemy1;
        // enemyList[1] = enemy2;
        // enemyList[2] = enemy3;
    }

    // Update is called once per frame
    void Update()
    {
        int index;
        CreatTime -= Time.deltaTime;
        if (CreatTime<=0)    //如果倒计时为0 的时候
        {  
            //CreatTime = Random.Range(3, 10);
            CreatTime = 0f;
            timerWave += Time.deltaTime;
            //int index = Random.Range(0, 3);
            index = WordController.GetCurChar() - 'A';
            if (flag == 0) {
                spawnPerfab = enemyList[index];
                flag = 1;
            }
            else {
                spawnPerfab = enemyList[Random.Range(0, enemyList.Length)];
            }
            
            if(timerWave < timeWave && countPerWave != 5) {
                timerOne += Time.deltaTime;
                if(timerOne > timeOne && ScoreScript.lives > 0) {
                    Instantiate (spawnPerfab, v[Random.Range(0, 8)], spawnPerfab.transform.rotation);
                    countPerWave++;
                    timerOne -= timeOne;
                }
            }
            if (timerWave >= timeWave) {
                timerWave -= timeWave;
                countPerWave = 0;
                flag = 0;
            }
        }
    }
}