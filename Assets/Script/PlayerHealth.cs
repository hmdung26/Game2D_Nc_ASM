using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameOV_UI GameOvUI;
    public float maxhealth;
    private Animator ani;
    private float currenHealth;

    public GameObject bloodEffect;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        currenHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        efHPScript efHpScript = GetComponent<efHPScript>();
        if (damage <= 0)
            return;
        currenHealth -= damage;
        efHpScript.playerhpslider.value = currenHealth;
        if (currenHealth <= 0)
        {
            makeDead();
            
        }
    }
    void makeDead()
    {
        // ani.SetBool("isDie",true);
        Destroy(gameObject);
        GameOvUI.Setup();
    }
}
