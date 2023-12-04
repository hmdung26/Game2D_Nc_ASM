using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOV_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void OutMenu() {

        SceneManager.LoadScene(0);


    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame 
    void Update()
    {
        
    }
}
