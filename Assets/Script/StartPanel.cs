using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Quit()
    {
        Application.Quit();
    }

    void EnterGame()
    {
        SceneManager.LoadScene("Adventure_1_4");
    }

    void Option()
    {
        Time.timeScale = 0;
        ShowOptions();
    }

    void ShowOptions()
    {

    }
}
