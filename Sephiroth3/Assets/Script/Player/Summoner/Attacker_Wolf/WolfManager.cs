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
        GetNowRound();
        _summonerFettle._hpData.ArmorValue += nowRound;
        if (LocationManager.instance.PlayerLocation[0] != this._summonerFettle)
        {
            
            //Debug.Log("IsNullA");
            LocationManager.instance.PlayerLocation[3] = LocationManager.instance.PlayerLocation[0];
            LocationManager.instance.PlayerLocation[4] = LocationManager.instance.PlayerLocation[1];
            LocationManager.instance.PlayerLocation[0] = this.gameObject.GetComponent<FettleGeneric>();
            LocationManager.instance.PlayerLocation[1] = LocationManager.instance.PlayerLocation[3];
            LocationManager.instance.PlayerLocation[2] = LocationManager.instance.PlayerLocation[4];
            for (int i = 0; i < 3; i++)
            {
                //Debug.Log("IsNullB");
                LocationManager.instance.PlayerLocation[i].StatyLocation = i;
            }
        }
    }
}
