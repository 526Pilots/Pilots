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
        // GameObject TargetEnemyColorIndictor = GameObject.FindWithTag("TargetEnemyColorIndictor");
        // int color = TargetEnemyColorIndictor.GetComponent<TargetEnemyColorIndictor>().color;

        // int color = TargetEnemyColorIndictor.color;
        // string colorText = "Undefined";
        // if (color == 1) {
        //     colorText = "Red";
        // } else if (color == 2) {
        //     colorText = "Green";
        // } else if (color == 3) {
        //     colorText = "Yellow";
        // }
        // score.text = "Score: " + scoreValue + "  Lives: " + lives +"  Target Color: " +colorText;
        score.text = "Score: " + scoreValue + "  Lives: " + lives;
    }
}

