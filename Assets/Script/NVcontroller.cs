using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NVcontroller : MonoBehaviour
{
    private bool QuayPhai = true;
    private float TocDo = 0;
    public float maxSpeed;
    public float NhayCao=850;
    public float NhayThap=5;
    public float RoiXuong = 5;
    bool ground = true;
    public float radius;
    public GameObject kame;
    public LayerMask enemies;
    public GameObject attackPoint;
    public GameObject PauseMenuScreen;
    public Text textKey;
    public WINGAME _wingame;
    public int key = 0;
    private float musicvolume=1f;
    public Joystick joystick;
    
    
    public float dame;
    // Start is called before the first frame update
      Rigidbody2D myBody2d;
      Animator myAnim;
      private AudioSource AmThanh;
    void Start()
    {
        textKey = GameObject.Find("Key").GetComponent<Text>();
        AmThanh=GetComponent<AudioSource>();
        myBody2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        
    }
    void Update()
    {
        AmThanh.volume = musicvolume;
        myAnim.SetFloat("speed", TocDo);
        myAnim.SetBool("DuoiDat",ground);
        nhay2();
        if (Input.GetKeyDown(KeyCode.F))
        {
            myAnim.SetBool("Attack",true);
            attack();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            //rg.AddForce(Vector2.up*10f,ForceMode2D.Impulse);
            //anm.SetBool("status",true);
            chuong item = kame.GetComponent<chuong>();
            Instantiate(kame, transform.position, Quaternion.identity);

        }

        mobiejoystick();
    }

    void mobiejoystick()
    {
        float X = joystick.Horizontal * TocDo;
        myBody2d.AddForce(Vector2.right * X);
    }

    private void FixedUpdate()
    {
        dichuyen2();
        
        
    }

    private void dichuyen2()
    {
        float PhimNhanPhaiTrai = Input.GetAxis("Horizontal");
        myBody2d.velocity = new Vector2(maxSpeed*PhimNhanPhaiTrai, myBody2d.velocity.y);
        TocDo = Mathf.Abs(maxSpeed * PhimNhanPhaiTrai);
        if(PhimNhanPhaiTrai>0 && !QuayPhai) HuongMatNv();
        if(PhimNhanPhaiTrai<0&& QuayPhai) HuongMatNv();
    }

    private void nhay2()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground == true)
        {
            myBody2d.AddForce((Vector2.up)*NhayCao);
            
            ground = false;
        }
        /// lực hút xuống nhanh
        if (myBody2d.velocity.y < 0)
        {
            myBody2d.velocity += Vector2.up * Physics2D.gravity.y * (RoiXuong - 1) * Time.deltaTime;
        }
        else if (myBody2d.velocity.y>0&& !Input.GetKey(KeyCode.Space))
        {
            myBody2d.velocity += Vector2.up * Physics2D.gravity.y * (NhayThap - 1)*Time.deltaTime;
        }
        
      
        
    }
    void HuongMatNv()
    {
        QuayPhai = !QuayPhai;
        Vector2 HuongQuay = transform.localScale;
        HuongQuay.x *= -1;
        transform.localScale = HuongQuay;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "nendat")
        {
            ground = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
     {
         if (col.tag == "nendat")
         {
             ground = true;
         }

         if (col.tag=="key")
         {
             key++;
             textKey.text = "Key: " + key.ToString();
             Debug.Log("So key"+key);
             if (key == 4)
             { 
                 _wingame.Setup();
             }
         }
        
     }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("1 chém");
            enemyGameobject.GetComponent<healthEnemy>().health -= dame;
        }
    }
    

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position,radius);
    }

    public void endAttack()
    {
        myAnim.SetBool("Attack",false);
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
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Setvolume(float vol)
    {
        musicvolume = vol;
    }
    
}
