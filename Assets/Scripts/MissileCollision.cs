using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
	public GameObject explosion;


	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "brick")
		{
			Destroy(gameObject);
			explosion.SetActive(true);
		}
	}
}
