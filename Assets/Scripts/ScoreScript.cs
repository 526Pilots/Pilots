using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int lives = 3;
    public Text score;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue + "  Lives: " + lives;
    }
}

