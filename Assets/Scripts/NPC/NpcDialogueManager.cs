using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcDialogueManager : MonoBehaviour
{
    [Header("UI-Aspects")]
    public GameObject NpcCanvas;
    public TextMeshProUGUI dialogueTxt;

    [Header("Dialogues")]
    public NpcScriptableObject Data;
    [SerializeField] int DialogueCounter;

    [Header("PlayerDetect")]
    [SerializeField] bool PlayerInRange;
    public bool StopWalking;
    public LayerMask PlayerLayer;
    private bool IsFollowingPlayer;

    private int InterpelationCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Data.HasFinishedTalking)
        {
            DialogueCounter++;

            if (Data.hasInterpelations)
            {
                 CheckInterpelations();
            }
        }
        
        if(Data.Dialogues.Length < DialogueCounter)
        {
            dialogueTxt.text = Data.Dialogues[DialogueCounter];
        }
        else
        {
            Data.HasFinishedTalking = true;
        }

        //Player Follow

        if (IsFollowingPlayer)
        {
            StopWalking = Physics.CheckSphere(transform.position, 5f, PlayerLayer);

            if (!StopWalking)
            {
                //move and animate
            }
        }

    }

    private void CheckInterpelations()
    {
        for (int i = 0; i < Data.DialogueInterpelations.Length; i++)
        {
            if (Data.DialogueInterpelations[i] == DialogueCounter)
            {
                ActivateInterpelation();
            }
        }
    }

    private void ActivateInterpelation()
    {
        InterpelationCounter++;

        if(InterpelationCounter == 1)
        {
            ActivateMission();
        }

        if(InterpelationCounter == 2)
        {

        }
    }

    private void ActivateMission()
    {
        IsFollowingPlayer = true;
    }
}
