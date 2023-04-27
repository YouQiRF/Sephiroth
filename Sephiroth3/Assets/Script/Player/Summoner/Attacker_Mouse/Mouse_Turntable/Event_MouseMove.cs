using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_MouseMove : TurntableGeneric
{
    public override void OnPointed()
    {
        Debug.Log("OnMove");
    }
}
