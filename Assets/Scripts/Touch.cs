using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Touch : MonoBehaviour
{
    public static Action<Vector3> OnTouch = delegate { };

    public void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            OnTouch(hit.point);
        }
    }

}
