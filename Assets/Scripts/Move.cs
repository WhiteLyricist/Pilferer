using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        SceneController.OnTouch += Movement;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Movement(Vector3 tab) 
    {
        tab = new Vector3(tab.x, transform.position.y, tab.z);
        navMeshAgent.SetDestination(tab);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
