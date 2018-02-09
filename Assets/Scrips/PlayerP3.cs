using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerP3 : MonoBehaviour 
{

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 4.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f;

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);

    }
        void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Bala")
        {

            Destroy(gameObject);
        }

    }

}
