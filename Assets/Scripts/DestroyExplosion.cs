using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{   
    float times = 2f;

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
            Destroy(gameObject);
        }
    }
}
