using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : SummonerManager
{
    public override void OnStart()
    {
        base.OnStart();
        _summonerFettle = FindObjectOfType<MouseFettle>();
    }
    public override void OnSummoner()
    {
        GetNowRound();
    }
}
