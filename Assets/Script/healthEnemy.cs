using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthEnemy : MonoBehaviour
{
    public float currenhealth;
    public float health;
    public bool drop;
    public GameObject theDrop;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currenhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < currenhealth)
        {
            currenhealth = health;
            anim.SetTrigger("isAttack");
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            if (drop)
            {
                Instantiate(theDrop, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
