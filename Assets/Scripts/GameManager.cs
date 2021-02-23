using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    public static void Restart(){
        SceneManager.LoadScene(0);
    }
    public static void Quit(){
        Application.Quit();
    }

}
