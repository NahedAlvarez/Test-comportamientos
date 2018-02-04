using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {


   Vector3 mousePosition;
    Vector3 dir;

    private void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));

       dir=mousePosition;
    }
    private void Update()
    {
        transform.Translate(dir * 10 * Time.deltaTime, Space.World);
    }
}
