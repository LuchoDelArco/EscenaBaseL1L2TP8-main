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

    [Header("Others")]
    public bool isFlying; //PARA LA ANIMACION (NO SE COMO HACERLO) TIPO CUADO ES TRUE QUE HAGA LA ANIMACION
    public Animator[] PropellerAnim;

    Rigidbody DroneRb;		
	bool spacePressed;

    void Start()
    {
        DroneRb = GetComponent<Rigidbody>();
        //PropellerAnim = transform.Find("Helice1").GetComponent<Animator>();
    }

    void Update ()
    {
		
	}

	void FixedUpdate ()
    {

        DroneRb.AddForce(0,9,0);//PARA QUE EL DRONE NO PIERDA ALTURA MUY RAPIDO, SI NO QUIERO PERDER ALTURA NUNCA CAMBIAR A 9.80665 O DESACTIVAR LA GRAVEDAD DEL RIGIDBODY
        
        if (Input.GetKey(KeyCode.W)) //AVANZAR
        {
            isFlying = true;
            DroneRb.AddForce(transform.forward * ForwardBackwardSpeed);
        }        
        else if (Input.GetKeyUp(KeyCode.W))
        {
            isFlying = false;
        }

        if (Input.GetKey(KeyCode.S)) //RETROCEDER
        {
            isFlying = true;
            DroneRb.AddForce(-transform.forward * ForwardBackwardSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            isFlying = false;
        }

        if (Input.GetKey(KeyCode.A)) //IZQUIERDA
        {
            isFlying = true;
            DroneRb.AddForce(-transform.right * LeftRightSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            isFlying = false;
        }

        if (Input.GetKey(KeyCode.D)) //DERECHA
        {
            isFlying = true;
            DroneRb.AddForce(transform.right * LeftRightSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isFlying = false;
        }

        if (Input.GetKey(KeyCode.UpArrow) && spacePressed == false) //SUBIR
        {
            isFlying = true;
            DroneRb.AddForce(transform.up * UpDownSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) && spacePressed == false)
        {
            isFlying = false;
        }

        if (Input.GetKey(KeyCode.DownArrow) && spacePressed == false) //BAJAR
        {
            DroneRb.AddForce(-transform.up * UpDownSpeed);
            isFlying = false;            
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //GIRAR IZQUIERDA
        {
            DroneRb.transform.localEulerAngles = new Vector3(DroneRb.transform.localEulerAngles.x, DroneRb.transform.localEulerAngles.y - RotateSpeed, DroneRb.transform.localEulerAngles.z);
        }

        if (Input.GetKey(KeyCode.RightArrow)) //GIRAR DERECHA
        {
            DroneRb.transform.localEulerAngles = new Vector3(DroneRb.transform.localEulerAngles.x, DroneRb.transform.localEulerAngles.y + RotateSpeed, DroneRb.transform.localEulerAngles.z);
        }

        //                  PARA ALTERNAR SI SE QUEDA ESTATICO
        if (Input.GetKeyDown(KeyCode.Space)) //MANTENER ALTURA
        {
            if (spacePressed == false) //ESTATICO
            {
                isFlying = true;
                spacePressed = true;
                DroneRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

                return;
            }
            else if (spacePressed == true) //NO ESTATICO
            {
                isFlying = false;
                spacePressed = false;
                DroneRb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        ////              PARA DEJAR ESTATICO CUANDO SE ESTA PRESIONANDO      
        //if (Input.GetKeyDown(KeyCode.Space)) //ESTABILIZAR
        //{
        //    DroneRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //    isFlying = true;
        //}
        //else if (Input.GetKeyUp(KeyCode.Space)) //DEJAR DE ESTABILIZAR
        //{
        //    DroneRb.constraints = RigidbodyConstraints.FreezeRotation;
        //    isFlying = false;
        //}

        //if (Input.GetKeyDown(KeyCode.R)) //PARA DESTRABARTE SI TE QUEDAS DADO VUELTA O ALGO
        //{
        //    DroneRb.transform.position = new Vector3(DroneRb.transform.position.x, DroneRb.transform.position.y + 0.5f, DroneRb.transform.position.z);
        //    DroneRb.transform.rotation = Quaternion.Euler(0, 0, 0);
        //}


        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 🔽 NO FUNCIONA 🔽 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
                                                                                            //
        if (isFlying)                                                                       //
        {                                                                                   //
            PropellerAnim[0].SetBool("isFlyingAnim", true);                                 //
            PropellerAnim[1].SetBool("isFlyingAnim", true);                                 //
            PropellerAnim[2].SetBool("isFlyingAnim", true);             //  //              //
            PropellerAnim[3].SetBool("isFlyingAnim", true);             //  //              //
                                                                                            //
            Debug.Log("Girando Helices");                            //         //          //
        }                                                           //          //          //
        else                                                          //      //            //
        {                                                               /////               //
            PropellerAnim[0].SetBool("isFlyingAnim", false);                                //
            PropellerAnim[1].SetBool("isFlyingAnim", false);                                //
            PropellerAnim[2].SetBool("isFlyingAnim", false);                                //
            PropellerAnim[3].SetBool("isFlyingAnim", false);                                //
                                                                                            //
            Debug.Log("Parando Helices");                                                   //
        }                                                                                   //
                                                                                            //
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 🔼 NO FUNCIONA 🔼 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
        

        //Repoducir la animacion "isFlyingAnim" de la helice si isFlying es verdadero pero si es falso detener la animacion

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