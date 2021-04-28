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
    
    public void next() {
        SceneManager.LoadScene(0);
    }
}

