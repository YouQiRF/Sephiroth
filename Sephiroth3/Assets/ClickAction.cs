using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class ClickAction : MonoBehaviour
{
    public UnityEvent Onclick;

    private void OnMouseDown()
    {
        Onclick.Invoke();
    }
}
