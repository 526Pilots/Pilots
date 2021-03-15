using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordController : MonoBehaviour
{
    string[] sentences = { "TAKECARE", "GOODLUCK", "ILOVEYOU" };
    int sentencesIndex;
    public static int curIndex = 0;
    public static char[] thisSentence;
    // Start is called before the first frame update
    void Start()
    {
        sentencesIndex = Random.Range(0, 3);
        thisSentence = sentences[sentencesIndex].ToCharArray();
    }

    public static void CheckCharacter(char cr)
    {
        char curChar = GetCurChar();
        if (cr != curChar)
        {
            curIndex = curIndex > 2 ? 0 : curIndex - 2;
        }
        else
        {
            curIndex++;
            if(curIndex >= 8) {
                SceneManager.LoadScene("Scenes/GameOver");
            }
        }
    }

    public static char GetCurChar()
    {
        return thisSentence[curIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
