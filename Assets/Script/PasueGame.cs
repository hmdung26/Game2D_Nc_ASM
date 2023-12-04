using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasueGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseMenuScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuScreen.SetActive(true);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuScreen.SetActive(false);
    }
}
