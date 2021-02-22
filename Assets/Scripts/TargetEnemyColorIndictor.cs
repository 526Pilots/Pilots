using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemyColorIndictor : MonoBehaviour
{   
    float times = 5f;
    public int color = 1; // 1:red, 2:green, 3:yellow
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        times -= Time.deltaTime;
        if (times < 0)
        {
            color = Random.Range(1,4);
            times = 5f;
        }
    }
    
    int GetColor() {
        return color;
    }
}
