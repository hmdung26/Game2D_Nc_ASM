using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Vector3 direction = Vector3.right;// thay đổi chiều của viên đạn

    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("quai"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        
    }
}
