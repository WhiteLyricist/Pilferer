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
        if (collision.gameObject.name == "Exhibit") //Подбор предмета что бы пройти уровень.
        {
            theft = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Finish" && theft == true) //Проверка поднят ли предмет что бы пройти уровень.
        {
            theft = false;
            Debug.Log("Новый уровень!");
        }

    }

    void Movement(Vector3 tab) //Перемещение при нажатии на пол.
    {
        tab = new Vector3(tab.x, transform.position.y, tab.z);
        navMeshAgent.SetDestination(tab);
    }

    private void OnDestroy()
    {
        Touch.OnTouch -= Movement;
    }

}
