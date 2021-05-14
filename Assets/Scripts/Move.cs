using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{

    public static Action<bool> OnStop = delegate { };

    private float speed = 5f;
    private bool update=false;
    private Vector3 touch;

    // Start is called before the first frame update
    void Start()
    {
        SceneController.OnTouch += Movement;
    }

    void Movement(bool flag, Vector3 tab) 
    {
        update = flag;
        touch = tab;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnStop(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!update) return;
        Vector3 point =  Camera.main.ScreenToWorldPoint(touch);
        point.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
        if (transform.position.x == point.x && transform.position.y == point.y) OnStop(false);
    }
}
