using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlManager : SummonerManager
{
    // Start is called before the first frame update
    public override void OnStart()
    {
        base.OnStart();
        _summonerFettle = FindObjectOfType<OwlFettle>();
    }

    public override void OnSummoner()
    {
        GetNowRound();
        var Player = FindObjectOfType<PlayerFettle>();
        Player._hpData.NowHP += (nowRound + 1);
        LocationManager.instance.PlayerLocation[Player.StatyLocation].GetHealEffect();
    }
}
