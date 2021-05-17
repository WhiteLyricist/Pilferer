using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private bool theft = false;

    // Start is called before the first frame update
    void Start()
    {
        Touch.OnTouch += Movement;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Exhibit") 
        {
            theft = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Finish" && theft == true) 
        {
            Debug.Log("Новый уровень!");
        }

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
