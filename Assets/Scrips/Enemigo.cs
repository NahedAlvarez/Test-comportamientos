using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour 
{
    public string npcState;

    /*
    PATRULLAR
    ESPERAR     
    ATACAR
    */
    public Transform[] patrolpoint;
    int Point = 0;
    public float velocity;
    float waitTime = 1;
    float countWaitTime;
    public Transform target;
	public Transform spawnPointShoot;
	public Transform projectile;
	float countShootTime;
    NavMeshAgent agente;
    


    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.destination = patrolpoint[0].position;
       // agente.autoBraking = false;
        countWaitTime = waitTime;
		countShootTime = waitTime;
    }

    public void Estado(string state)
    {
        npcState = state;
    }

    public void MovementNextPoint()
    {
        agente.destination = patrolpoint[Point].position;
    }


    private void  Update()
   {
        switch (npcState)
        {
            case "PATRULLAR":

                if (transform.position.x == patrolpoint[Point].position.x)
                {  
                    if(transform.position.z == patrolpoint[Point].position.z)
                    {
                        Point++;
                        // transform.LookAt(patrolpoint[Point]);
                        //Debug.Log(Point);
                        npcState = "ESPERAR";
                        if (Point >= patrolpoint.Length)
                        {
                            
                            Point = 0;
                          
                        }
                        if (npcState == "PATRULLAR")
                            MovementNextPoint();
                    }
                   
                }
               

                break;
            case "ESPERAR":

                countWaitTime -= Time.deltaTime;
                if (countWaitTime <= 0)
                {
                    countWaitTime = waitTime;
                    if(npcState != "ATACAR")
                    npcState = "PATRULLAR";
                    agente.destination = patrolpoint[Point].position;

                }
                
                break;
		case "ATACAR":


			countShootTime -= Time.deltaTime;

               // float dist = Vector3.Distance(other.position, transform.position);
               // transform.LookAt(target);
			spawnPointShoot.LookAt (target);
                if (target != null)
                {
                    if (Vector3.Distance(transform.position, target.position) >= 16)
                    {
                        agente.destination = target.position;
                    }
                }
                

			if (countShootTime <= 0) 
			{
		
				countShootTime = waitTime;
				Disparar ();
			}


			if (target == null) 
			{
				
				npcState = "PATRULLAR";
                    MovementNextPoint();

            }

                
                break;

        }
   }

    void OnTriggerEnter(Collider other)
    {
       if (other.tag  == "PatrollZone" && npcState != "Atacar")
        {
            npcState = "PATRULLAR";
        }


    }

	public void Disparar()
	{
			Instantiate (projectile, spawnPointShoot.position, Quaternion.identity);

	}



   

}
