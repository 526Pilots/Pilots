using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Skin : MonoBehaviour
{
    void Start()
    {   
    }
    
    public void selectModel(int modelIndex) {
        Global.playerModel = modelIndex;
        // GameManager.Play();
        SceneManager.LoadScene("Scenes/Level");
    }
}

