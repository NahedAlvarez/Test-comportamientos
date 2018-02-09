using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    Vector3 mousePosition;
   public Transform bala;
   public  GameObject SpawnPoint;

   
    void Update()
    {
        Movement();
        Disparar();
    }
    void Movement()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.Translate(0, z, 0);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
    }
    void Disparar()
    {
        Transform BalaDisparada;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pum");
            BalaDisparada = Instantiate(bala, SpawnPoint.transform.position, Quaternion.identity);
        }
       
    }

    /*
      //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //  Vector2 MS = Input.mousePosition;
      //  float Compare = Vector2.Angle(new Vector2(transform.position.x, transform.position.y), new Vector2(MS.x, MS.y));
      // transform.LookAt(pz);
      //  Vector3 n=(new Vector3(0, 0, -pz.x*pz.y));
      // Vector3 Rot = new Vector3(0, 0, Compare);
       // transform.LookAt(new Vector3(MS.x, MS.y, 0));
      // transform.Rotate(new Vector3(0,0,n.z));
     * */


    /*
     * 
     //Gets the mouse position
mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));
 
//Draws a ray from the pivot point from object to the mouse position
Debug.DrawRay(transform.position, mousePosition - transform.position, Color.cyan);
 
//Rotates the object
transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);


     * */
}
