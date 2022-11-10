using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    private NpcDialogueManager Manager;
    private GameObject DronController;
    public bool HasController;


    private bool FirstInterpelation = true;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GetComponent<NpcDialogueManager>();
        DronController = GameObject.FindGameObjectWithTag("DronController");
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.InterpelationCounter == 0 && FirstInterpelation)
        {

            Manager.ActivateMission();
            Manager.FollowPlayer();



            FirstInterpelation = false;
        }
    }

    private void FindingControllerMission()
    {

        HasController = false;
        DronController.SetActive(true);

    }

}
