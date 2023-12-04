using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nambay : MonoBehaviour
{
    public float pushbackForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("bay");
            Vector2 pushDirect =
                new Vector2(0, (col.transform.position.y - col.gameObject.transform.transform.position.y)).normalized;
            pushDirect *= pushbackForce;
            Rigidbody2D pushRB = col.gameObject.transform.gameObject.GetComponent<Rigidbody2D>();
            pushRB.velocity = Vector2.zero;
            pushRB.AddForce(pushDirect, ForceMode2D.Impulse);

        }
    }
}

//     void pushBack( Transform pushedObject)
//     {
//         Vector2 pushDirect = new Vector2(0, (pushedObject.position.y - pushedObject.transform.position.y)).normalized;
//         pushDirect *= pushbackForce;
//         Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
//         pushRB.velocity = Vector2.zero;
//         pushRB.AddForce(pushDirect, ForceMode2D.Impulse);
//     }
// }
