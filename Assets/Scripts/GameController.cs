using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // public GameObject hazard;
	// public Vector3 spawnValues;

	// void Start () 
	// {
	// 	SpawnWaves();
		
	// }

	// void SpawnWaves()
	// {
	// 	Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x), spawnValues.y, spawnValues.z);
	// 	Quaternion spawnRotation = Quaternion.Euler(new Vector3(90, 0, 180));
	// 	Instantiate(hazard, spawnPosition, spawnRotation);
	// }

    public GameObject hazard;
	public Vector3 spawnValues;

	public int hazardCount;	//一批敌人的数量
	public float spawnWait;	//一批中，单个敌人生成的间隔时间
	public float startWait;	//开始的暂停时间
	public float waveWait; //两批敌人之间的间隔时间

	void Start () 
	{
		
		StartCoroutine(SpawnWaves());
		
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for(int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x), 0, spawnValues.z);
				// Quaternion spawnRotation = Quaternion.identity;
		        Quaternion spawnRotation = Quaternion.Euler(new Vector3(90, 0, 180));
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
}
