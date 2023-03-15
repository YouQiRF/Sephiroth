using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_OwlDoubleHeal : TurntableGeneric
{
    public override void OnPointed()
    {
        var CheckBool = FindObjectOfType<OwlFettle>();
        if (!CheckBool.DoubleReady)
        {
            CheckBool.DoubleReady = true;
        }
    }
}
