using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{

    public bool isPickable = true;
    public bool isPicked;

    void Update()
    {

    }

    private void OnTriggerEnter(Collider col) //Detecta que el objeto entro en un trigger
    {
        if (col.tag == "InteractionZone") //Se fija que si lo que esta tocando es la zona de interaccion que le puse al player
        {
            col.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject; //busca en su padre el script PickUpObject y adentro de ese script busca la variable y le asigna nuestro player, le cambio el padre
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "InteractionZone")
        {
            col.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
        }
    }
}