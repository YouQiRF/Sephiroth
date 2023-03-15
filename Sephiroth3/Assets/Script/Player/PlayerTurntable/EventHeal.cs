using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHeal : TurntableGeneric
{
    public override void OnPointed()
    {
        var Player = FindObjectOfType<PlayerManager>();
        Player._playerFettle._hpData.NowHP += 1;
        Player._playerFettle.GetHealEffect();
    }
}
