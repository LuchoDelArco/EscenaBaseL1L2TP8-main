using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject[] Platform = new GameObject[2];

	public GameObject smoke;
	public Rigidbody Rb;
	public int speed;

	public float brickMass;

	Rigidbody brickRb; 


	[SerializeField] GameObject[] arrayLadrillos;

    // Start is called before the first frame update
    void Start()
    {
		arrayLadrillos = GameObject.FindGameObjectsWithTag("brick");
    }

    // Update is called once per frame
    void Update()
    {
        if (Platform[0].GetComponent<PlatformScript>().cubeOn && Platform[1].GetComponent<PlatformScript>().cubeOn)
        {
            //LUCHO, PONE ACA LO QUE QUERES QUE PASE UNA VEZ QUE EL DRONE YA HIZO LO DE LOS CUBITOS
            Debug.Log("Ambos presionados");

			smoke.SetActive(true);
            Rb.constraints = RigidbodyConstraints.None;
            Rb.velocity = transform.right * -speed;
			AgregarRb();

		}
	}

	void AgregarRb()
	{
		foreach (GameObject go in arrayLadrillos)
		{
			brickRb = go.AddComponent<Rigidbody>();
			brickRb.mass = brickMass;
		}
	}
}
