using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronControllerBehaviour : MonoBehaviour
{
    private NpcBehaviour Npc;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Npc = GameObject.Find("NPC").GetComponent<NpcBehaviour>();

            StartCoroutine(DesactivateGO());
        }
    }

    IEnumerator DesactivateGO()
    {

        yield return new WaitForSeconds(1f);

        Npc.HasController = true;
        gameObject.SetActive(false);
    }

}
