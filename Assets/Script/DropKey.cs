using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropKey : MonoBehaviour
{
    public Text textKey;
    private WINGAME _wingame;
    public int key = 0;
    // Start is called before the first frame update
    void Start()
    {
        textKey = GameObject.Find("Key").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            // key++;
            // textKey.text = "Key: " + key.ToString();
            // Debug.Log("so key :"+key);
            Destroy(gameObject);
            
        }
       

        
    }
}
