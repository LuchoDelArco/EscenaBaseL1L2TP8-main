using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    private NpcDialogueManager Manager;
    public GameObject DronController;
    private DronViewScript DronView;

    public bool HasController = false;
    private bool FirstInterpelation = true;
    private bool FinishFirstMission = true;

    public bool HasActivatedRocket = false;
    private bool SecondInterpelation = true;
    private bool FinishSecondMission = true;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GetComponent<NpcDialogueManager>();
        DronView = GetComponent<DronViewScript>();
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
            ActivateDronMission();
            Manager.ActivateMission();

            SecondInterpelation = false;
        }

        if (HasActivatedRocket && FinishSecondMission)
        {
            Manager.FinishMission();
            Manager.DialogueCounter++;


            FinishSecondMission = false;
        }

    }

    private void FindingControllerMission()
    {

        HasController = false;
        DronController.SetActive(true);

    }

    private void ActivateDronMission()
    {
        DronView.CanSwichViewActivation();
    }

}
