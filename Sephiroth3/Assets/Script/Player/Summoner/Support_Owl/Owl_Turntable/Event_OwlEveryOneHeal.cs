using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_OwlEveryOneHeal : TurntableGeneric
{
    public override void OnPointed()
    {
        var IsDouble = FindObjectOfType<OwlFettle>();
        //float HealNumber = IsDouble.DoubleReady == true ? 4 : 2;

        for (int i = 0; i < 3; i++)
        {
            if (LocationManager.instance.PlayerLocation[i] != null)
            {
                LocationManager.instance.PlayerLocation[i]._hpData.NowHP ++;
                LocationManager.instance.PlayerLocation[i].GetHealEffect();
            }
        }
    }
}
