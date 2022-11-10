using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private bool IsOnMission;

    //Other
    private Animator NpcAnimator;
    private NavMeshController NpcNav;

    private int InterpelationCounter = -1;
    private bool[] InterpelationBools;

    // Start is called before the first frame update
    void Start()
    {
        NpcAnimator = GetComponent<Animator>();
        NpcNav = GetComponent<NavMeshController>();
        NpcCanvas.SetActive(false);

        InterpelationBools = new bool[Data.DialogueInterpelations.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange)
        {
            if (IsOnMission)
            {
                NpcCanvas.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E) && Data.HasFinishedTalking && !IsOnMission)
            {
                DialogueCounter++;

                if (Data.hasInterpelations)
                {
                     CheckInterpelations();
                }
            }
        
            if(Data.Dialogues.Length > DialogueCounter)
            {
                dialogueTxt.text = Data.Dialogues[DialogueCounter];
            }
            else
            {
                Data.HasFinishedTalking = true;
            }

        }

        if (IsFollowingPlayer)
        {
            StopWalking = Physics.CheckSphere(transform.position, 1f, PlayerLayer);

            if (!StopWalking)
            {
                //move and animate

                if (NpcAnimator)
                {
                    NpcAnimator.SetBool("IsWalking", true);
                    NpcNav.navWalk();
                }

            }

            if (StopWalking)
            {
                if (NpcAnimator)
                {
                    NpcAnimator.SetBool("IsWalking", false);
                }
            }

        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerInRange = true;
            NpcCanvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInRange = false;
            NpcCanvas.SetActive(false);
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

        if(InterpelationCounter == 0)
        {
            Debug.Log("Interpelation");
            FollowPlayer();
            IsOnMission = true;
        }

        if(InterpelationCounter == 1)
        {

        }
    }

    private void FollowPlayer()
    {
        IsFollowingPlayer = true;
    }

    private void ActivateMission()
    {
        IsOnMission = true;
    }
}
