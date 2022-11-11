using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject cube;
    public bool cubeOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject == cube.gameObject)
        {
            col.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            cubeOn = true;
            col.gameObject.GetComponent<PickableObject>().isPickable = false;
            col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            col.gameObject.transform.position = new Vector3(transform.position.x, 0.9442f, transform.position.z);
            col.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    //void OnCollisionExit(Collision col)
    //{
    //    if (col.gameObject == cube.gameObject)
    //    {
    //        col.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    //        cubeOn = false;
    //    }
    //}

}
