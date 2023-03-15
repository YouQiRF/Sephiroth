using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_OwlEveryOneHeal : TurntableGeneric
{
    public override void OnPointed()
    {
        var HealTarget = FindObjectOfType<LocationManager>();
        var IsDouble = FindObjectOfType<OwlFettle>();
        float HealNumber = IsDouble.DoubleReady == true ? 4 : 2;

        for (int i = 0; i < 3; i++)
        {
            if (HealTarget.PlayerLocation[i] != null)
            {
                HealTarget.PlayerLocation[i]._hpData.NowHP += HealNumber;
                HealTarget.PlayerLocation[i].GetHealEffect();
            }
        }
    }
}
