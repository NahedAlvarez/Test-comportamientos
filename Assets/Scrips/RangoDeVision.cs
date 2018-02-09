using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoDeVision : MonoBehaviour
{
    public GameObject persona;



    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        persona.SendMessage("Estado","ATACAR");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            persona.SendMessage("Estado", "PATRULLAR");
            persona.SendMessage("MovementNextPoint");
    }


}
