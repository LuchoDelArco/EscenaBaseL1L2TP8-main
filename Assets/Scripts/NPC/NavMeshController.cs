using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public float walkSpeed;
    private NavMeshAgent agent;
    private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void navWalk()
    {
        agent.destination = Player.position;
        agent.speed = walkSpeed;
    }
}
