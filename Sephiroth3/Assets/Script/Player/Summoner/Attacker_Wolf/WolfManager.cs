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
    public override void OnSummoner()
    {
        var location = FindObjectOfType<LocationManager>();
        var addArmorValue = FindObjectOfType<PointerManager>();
        _summonerFettle._hpData.ArmorValue += addArmorValue.NowRound;
        if (location.PlayerLocation[0] != null)
        {
            location.PlayerLocation[3] = location.PlayerLocation[0];
            location.PlayerLocation[4] = location.PlayerLocation[1];
            location.PlayerLocation[0] = this.gameObject.GetComponent<FettleGeneric>();
            location.PlayerLocation[1] = location.PlayerLocation[3];
            location.PlayerLocation[2] = location.PlayerLocation[4];
            for (int i = 0; i < 3; i++)
            {
                location.PlayerLocation[i].StatyLocation = i;
            }
        }
    }
}
