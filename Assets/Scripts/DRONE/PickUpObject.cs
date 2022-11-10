using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class PickUpObject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone; //Ubicacion donde quiero que quede agarrado el objeto
    public Light light;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Generar un numero aleatorio para saber que mano agarra el objeto


        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            light.GetComponent<Light>().color = Color.green;

            if (Input.GetKeyDown(KeyCode.F))//Si toco la F suceda lo de abajo
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false; //Le avisamos que ya agarramos el objeto
                PickedObject.transform.SetParent(interactionZone); //Lo parenteamos
                PickedObject.transform.position = interactionZone.position;//Lo ponemos en la posicion de la zona de interaccion o donde queramos
                PickedObject.GetComponent<Rigidbody>().useGravity = false; //Para que lo agarremos y no se nos caiga
                PickedObject.GetComponent<Rigidbody>().isKinematic = true; //Para que no le afecte la fisica
                PickedObject.GetComponent<Rigidbody>().detectCollisions = false; //Para que no detecte colisiones
                ObjectToPickUp.GetComponent<PickableObject>().isPicked = true;

            }
        }


        else if (PickedObject != null) //Si ya agarramos algo
        {
            if (Input.GetKeyDown(KeyCode.F)) //para soltar
            {
                PickedObject.GetComponent<PickableObject>().isPicked = false;
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject.GetComponent<Rigidbody>().detectCollisions = true;
                PickedObject = null;
            }
        }
        
        if (ObjectToPickUp == null)
        {
            light.GetComponent<Light>().color = Color.magenta;
        }

        if (PickedObject != null)
        {
            light.enabled = false;
        }
        else
        {
            light.enabled = true;
        }

    }
}
