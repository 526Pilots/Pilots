using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallWorker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddPlayerFireRate()
    {
        PlayerController.fireRate = (float)(PlayerController.fireRate*0.5);
    }

    public static void AddPlayerMoveSpeed()
    {
        PlayerController.speed += 10;
    }

    public static void AddPlayerLife()
    {
        ScoreScript.lives++;
    }
}
