using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfManager : SummonerManager
{
    public override void OnStart()
    {
        base.OnStart();
        _summonerFettle = FindObjectOfType<WolfFettle>();
    }

    public override void OnTick()
    {
        base.OnTick();
    }
}
