using UnityEngine;
using System.Collections;

public class DroneControlC : MonoBehaviour {

    [Header("Velocidades")]
    public float ForwardBackwardSpeed; 
	public float RotateSpeed; 
	public float LeftRightSpeed;  
	public float UpDownSpeed;

    [Header("Canvas")]
    public Canvas droneCanvas;

    Rigidbody DroneRb;		
	bool spacePressed;

    void Start()
    {
        DroneRb = GetComponent<Rigidbody>();
    }
    
	void Update ()
    {
		
	}

	void FixedUpdate ()
    {

        DroneRb.AddForce(0,9,0);//PARA QUE EL DRONE NO PIERDA ALTURA MUY RAPIDO, SI NO QUIERO PERDER ALTURA NUNCA CAMBIAR A 9.80665 O DESACTIVAR LA GRAVEDAD DEL RIGIDBODY
        
        if (Input.GetKey(KeyCode.W))
        {
            DroneRb.AddForce(transform.forward * ForwardBackwardSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            DroneRb.AddForce(-transform.forward * ForwardBackwardSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            DroneRb.AddForce(-transform.right * LeftRightSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            DroneRb.AddForce(transform.right * LeftRightSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            DroneRb.AddForce(transform.up * UpDownSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            DroneRb.AddForce(-transform.up * UpDownSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //GIRAR IZQUIERDA
        {
            DroneRb.transform.localEulerAngles = new Vector3(DroneRb.transform.localEulerAngles.x, DroneRb.transform.localEulerAngles.y - RotateSpeed, DroneRb.transform.localEulerAngles.z);
        }

        if (Input.GetKey(KeyCode.RightArrow)) //GIRAR DERECHA
        {
            DroneRb.transform.localEulerAngles = new Vector3(DroneRb.transform.localEulerAngles.x, DroneRb.transform.localEulerAngles.y + RotateSpeed, DroneRb.transform.localEulerAngles.z);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) //MANTENER ALTURA
        {
            if (spacePressed == false)
            {
                spacePressed = true;
                //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 🔽 NO FUNCIONA 🔽 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
                DroneRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 🔼 NO FUNCIONA 🔼 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
                
                return;
            }
            else if (spacePressed == true)
            {
                spacePressed = false;
                DroneRb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R)) //PARA DESTRABARTE SI TE QUEDAS DADO VUELTA O ALGO
        {
            DroneRb.transform.position = new Vector3(DroneRb.transform.position.x, DroneRb.transform.position.y + 0.5f, DroneRb.transform.position.z);
            DroneRb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

}

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 🔽 NO FUNCIONA 🔽 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=//


        //      if (Input.GetKey(KeyCode.A)) //MOVER IZQUIERDA
        //      {
        //          GetComponent<Rigidbody>().AddForce(-LeftRightSpeed, 0, 0);
        //      }

        //if (Input.GetKey(KeyCode.D)) //MOVER DERECHA
        //      {
        //          GetComponent<Rigidbody>().AddForce(LeftRightSpeed, 0, 0);
        //      }

        //if (Input.GetKey(KeyCode.W)) //AVANZAR
        //      {
        //          GetComponent<Rigidbody>().AddForce(0, 0, ForwardBackwardSpeed);
        //      }

        //      if (Input.GetKey(KeyCode.S)) //RETROCEDER
        //      {
        //          DroneRb.AddRelativeForce(0, 0, -ForwardBackwardSpeed);
        //      }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 🔼 NO FUNCIONA 🔼 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=//