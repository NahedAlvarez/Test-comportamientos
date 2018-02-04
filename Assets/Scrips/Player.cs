using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   float speed=2f;
   float trush = 250;
   bool jump = false;


    bool counBool;
   float count=1.2f;

   public BoxCollider2D colliderPlataforma;

   

    Rigidbody2D rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
  
    }
    private void Update()
    {
        if (counBool == true)
            count -= Time.deltaTime;
        if(count <= 0)
        {
            colliderPlataforma.isTrigger = false;
            count = 1.2f;
            counBool = false;
        }

  

        Movement();
    }

    void Movement()
    {
        var z = Input.GetAxis("Horizontal") *speed* Time.deltaTime * 3.0f;
        transform.Translate(z, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            rb.AddForce(Vector2.up*trush);

            jump = true;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {

        jump = false;

        if (col.gameObject.tag != "Floor" && Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.DownArrow))
        {

            counBool = true;
            colliderPlataforma = col.gameObject.GetComponent<BoxCollider2D>();
            colliderPlataforma.isTrigger = true;
           
        }

    }

   

}



