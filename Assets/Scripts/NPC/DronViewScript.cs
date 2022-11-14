using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronViewScript : MonoBehaviour
{
    public bool CanSwichView = false;
    private bool ActivatedDronView = false;
    public GameObject Dron;
    public GameObject MissileCam;
    public CharacterController PlayerController;
    private NpcBehaviour NpcHandler;

    public void CanSwichViewActivation()
    {
        CanSwichView = true;
        NpcHandler = GetComponent<NpcBehaviour>();
    }

    void Start()
    {
        Dron.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && CanSwichView == true && !ActivatedDronView)
        {
            PlayerController.enabled = false;
            Dron.SetActive(true);

            ActivatedDronView = true;
        }
    }

    public void ActivatePlayer()
    {
        StartCoroutine(ActivateSequence());
    }

    IEnumerator ActivateSequence()
    {
        Dron.SetActive(false);
        MissileCam.SetActive(true);

        yield return new WaitForSeconds(3f);

        ActivatePlayerMov();
    }

    private void ActivatePlayerMov()
    {
        PlayerController.enabled = true;
        NpcHandler.HasActivatedRocket = true;
        MissileCam.SetActive(false);
    }

}
