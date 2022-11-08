using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcData", menuName = "NpcData")]
public class NpcScriptableObject : ScriptableObject
{
    [Header("Dialogues")]
    public string[] Dialogues;
    public int[] DialogueInterpelations;

    [Header("Mission State")]
    public bool isOnMission;
    public bool isFollowingPlayer;
    public bool HasFinishedTalking;


}
