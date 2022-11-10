using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NpcDialogueManager : MonoBehaviour
{
    [Header("UI-Aspects")]
    public GameObject NpcCanvas;
    public GameObject Player;
    public TextMeshProUGUI dialogueTxt;

    [Header("Dialogues")]
    public NpcScriptableObject Data;
    public int DialogueCounter;

    [Header("PlayerDetect")]
    [SerializeField] bool PlayerInRange;
    public bool StopWalking;
    public LayerMask PlayerLayer;
    private bool IsFollowingPlayer;
    private bool IsOnMission;

    //Other
    private Animator NpcAnimator;
    private NavMeshController NpcNav;

    public int InterpelationCounter = -1;
    private bool[] InterpelationBools;

    // Start is called before the first frame update
    void Start()
    {
        NpcAnimator = GetComponent<Animator>();
        NpcNav = GetComponent<NavMeshController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        NpcCanvas.SetActive(false);

        RestartScriptableObject();

        InterpelationBools = new bool[Data.DialogueInterpelations.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange)
        {

            if (Input.GetKeyDown(KeyCode.E) && !Data.HasFinishedTalking && !IsOnMission)
            {
                DialogueCounter++;

                if (Data.hasInterpelations)
                {
                     CheckInterpelations();
                }
            }
        
            if(Data.Dialogues.Length > DialogueCounter && !IsFollowingPlayer)
            {
                dialogueTxt.text = Data.Dialogues[DialogueCounter];
            }
            
            if(Data.Dialogues.Length <= DialogueCounter)
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

            if (!IsOnMission)
            {
                NpcCanvas.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInRange = false;

            if (!IsOnMission)
            {
                NpcCanvas.SetActive(false);
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
    }

    public void FollowPlayer()
    {
        IsFollowingPlayer = true;
    }

    public void StopFollowingPlayer()
    {
        IsFollowingPlayer = false;
        NpcAnimator.SetBool("IsWalking", false);
    }

    public void ActivateMission()
    {
        IsOnMission = true;
        NpcCanvas.SetActive(false);
    }

    public void FinishMission()
    {
        IsOnMission = false;
        NpcCanvas.SetActive(true);
    }

    private void RestartScriptableObject()
    {
        Data.isOnMission = false;
        Data.HasFinishedTalking = false;
        Data.hasFinishedMission = false;
    }
}
