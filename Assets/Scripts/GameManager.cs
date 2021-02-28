using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

>>>>>>> 0d14ed7097ccfd795d52454565b2904118b368af
    // Update is called once per frame
    public static void Restart(){
        SceneManager.LoadScene(0);
    }
    public static void Quit(){
        Application.Quit();
    }

}
