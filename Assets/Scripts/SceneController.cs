using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneController : MonoBehaviour
{

    public static Action<bool, Vector3> OnTouch = delegate { };

    // [SerializeField] private GameObject prefabDisk;

    // private GameObject _disk;

    //  public static Vector3 touch;
     public static bool update = false;

     private void Awake()
      {
        /* if (_disk == null)
         {
             _disk = Instantiate(prefabDisk) as GameObject;
         }
        */
        Move.OnStop += Stop;
      }

    void Stop(bool flag)
    {
        update = flag;
        OnTouch(update, Vector3.zero);
    }

    private void Update()
    {
        if  (Input.touchCount>0) 
        {
            Touch tab = Input.GetTouch(0);
            if (tab.phase == TouchPhase.Began)
            {
                update = true;
                OnTouch(update, tab.position);
            }
        }
    }
}
