using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    private NpcDialogueManager Manager;
    private GameObject DronController;
    public bool HasController;


    private bool FirstInterpelation = true;
    private bool FinishFirstMission = true;

    private bool SecondInterpelation = true;
    private bool FinishSecondMission = true;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GetComponent<NpcDialogueManager>();
        DronController = GameObject.Find("DronController");
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.InterpelationCounter == 0 && FirstInterpelation)
        {

            Manager.ActivateMission();
            Manager.FollowPlayer();

            FindingControllerMission();


            FirstInterpelation = false;
        }

        if (HasController && FinishFirstMission)
        {
            Manager.FinishMission();
            Manager.StopFollowingPlayer();
            Manager.DialogueCounter++;

            FinishFirstMission = false;
        }

        if(Manager.InterpelationCounter == 1 && SecondInterpelation)
        {
             

            SecondInterpelation = false;
        }

    }

    private void FindingControllerMission()
    {

        HasController = false;
        DronController.SetActive(true);

    }

}
