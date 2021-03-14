using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SwitchText : MonoBehaviour
{
    public Text switchs;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {   
        switchs.text = "                Congratulations! \n   In Next Level, Try to Shoot enemy \n         in order of Red-Green-Blue";
        
    }
    
    void OnGUI()  
    {  
        //开始按钮  
        if(GUI.Button(new Rect(450,400,100,40),"Next Level "))  
        {  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }  
    }
}

