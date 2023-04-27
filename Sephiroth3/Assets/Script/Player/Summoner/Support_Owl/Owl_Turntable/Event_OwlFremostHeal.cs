using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_OwlFremostHeal : TurntableGeneric
{
    public override void OnPointed()
    {
        var HealTarget = FindObjectOfType<LocationManager>();
        var IsDouble = FindObjectOfType<OwlFettle>();
        for(int i = 0; i < 3; i++)
        {
            if (HealTarget.PlayerLocation[i] != null)
            {
                HealTarget.PlayerLocation[i]._hpData.NowHP += 2;
                HealTarget.PlayerLocation[i].GetHealEffect();
                break;
            }
        }
        
    }
}
