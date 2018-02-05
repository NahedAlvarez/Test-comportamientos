using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy : MonoBehaviour 
{
	public Transform Player;

	void Start()
	{
		transform.LookAt (Player);
	}
	void Update ()
	{

		transform.Translate(Vector3.forward* 10 * Time.deltaTime);	
	}


    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
