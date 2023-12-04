using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dameEnemy : MonoBehaviour
{
    public float damage;

    private float dameRate = 0.5f;

    private float nextDamage;
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerHealth.addDamage(damage);
            nextDamage = dameRate + Time.time;
        }
        
        }
}
