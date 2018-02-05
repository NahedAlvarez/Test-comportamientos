using UnityEngine;

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
    float waitTime = 3;
    float countWaitTime;

    public Transform target;



    void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolpoint[0].position, velocity * Time.deltaTime);
        countWaitTime = waitTime;
    }

    public void Atacar()
    {
        npcState = "ATACAR";
    }


    private void  Update()
   {
        switch (npcState)
        {
            case "PATRULLAR":
                if (transform.position == patrolpoint[Point].position)
                {  
                    Point++;
                    if (Point >= patrolpoint.Length)
                    {
                        Point = 0;
                        npcState = "ESPERAR";
                    }

                }
                transform.position = Vector3.MoveTowards(transform.position, patrolpoint[Point].position, velocity * Time.deltaTime);
                break;
            case "ESPERAR":

                countWaitTime -= Time.deltaTime;
                if (countWaitTime <= 0)
                {
                    countWaitTime = waitTime;
                    npcState = "PATRULLAR";
                }
                
                break;
            case "ATACAR":
                
                break;
            default:

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




   

}
