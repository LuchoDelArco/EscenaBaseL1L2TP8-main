using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcData", menuName = "NpcData")]
public class NpcScriptableObject : ScriptableObject
{
    public string[] Dialogues;
    public int[] DialogueInterpelations;

}
