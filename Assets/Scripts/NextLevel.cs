using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    void Start()
    {   
        
    }
    
    public void TaskOnClick()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void backToMain() {
        SceneManager.LoadScene(0);
    }
}

