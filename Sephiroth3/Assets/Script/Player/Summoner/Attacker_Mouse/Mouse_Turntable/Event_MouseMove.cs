using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_MouseMove : TurntableGeneric
{
    public override void OnPointed()
    {
        Debug.Log("OnMove");
        ChangeLocation();
    }
    
    private void ChangeLocation()
    {
        var thisFettle = FindObjectOfType<MouseFettle>();
        thisFettle.OnSetLocation();
    }
}
