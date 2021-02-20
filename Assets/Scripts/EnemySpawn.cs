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
    public GameObject spawnPerfab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerWave += Time.deltaTime;
        if(timerWave < timeWave && countPerWave != 5) {
            timerOne += Time.deltaTime;
            if(timerOne > timeOne) {
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
