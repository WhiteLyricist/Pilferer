using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] 

public class EnemyAI : MonoBehaviour
{

    NavMeshAgent navMeshAgent;

    [SerializeField] private Transform[] wayPoints;

    private int destPoint = 0;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        navMeshAgent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (wayPoints.Length == 0)
            return;

        navMeshAgent.destination = wayPoints[destPoint].position;
        destPoint = (destPoint + 1) % wayPoints.Length;
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
