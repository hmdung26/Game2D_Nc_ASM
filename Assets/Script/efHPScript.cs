using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class efHPScript : MonoBehaviour
{
    private Animator ani;
    public Slider playerhpslider;
    public GameObject bloodEffect;
    public float maxHealth;

    private float currenHealth;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        playerhpslider.maxValue = maxHealth;
        playerhpslider.value = maxHealth;
    }
    
    public void addDame(float damage)
    {
        
        if (damage <= 0)
        {
            currenHealth -= damage;
            playerhpslider.value = currenHealth;
        }

        if (currenHealth<=0)
        {
            makeDead();
        }
    }
    // chúc năng hồi máu 
    public void addHealth(float healthAmount)
    {
        currenHealth = currenHealth + healthAmount;
        if (currenHealth > maxHealth)
            currenHealth = maxHealth;
        playerhpslider.value = currenHealth;
    }
    private void makeDead()
    {
        // ani.SetBool("isDie",true);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
