using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

[RequireComponent(typeof(Renderer))]

public class Move : MonoBehaviour
{

    public static Action OnEnd = delegate { };

    private NavMeshAgent navMeshAgent;

    private bool theft = false;

    // Start is called before the first frame update
    void Start()
    {

        Color colorPlayer;  //Смена цвета игрока
        ColorUtility.TryParseHtmlString(PlayerColor.GamePlayerColor, out colorPlayer);
        GetComponent<Renderer>().material.color = colorPlayer;  

        Touch.OnTouch += Movement;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)  //Проверка на попадание в зону выхода и подбора предмета
    {
        if (collision.gameObject.name == "Exhibit") //Подбор предмета что бы пройти уровень.
        {
            theft = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Finish" && theft == true) //Проверка поднят ли предмет что бы пройти уровень.
        {
            theft = false;
            OnEnd();
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
