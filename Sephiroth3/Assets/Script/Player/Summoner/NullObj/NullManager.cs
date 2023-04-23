using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullManager : SummonerManager
{
    // Start is called before the first frame update
    public override void OnStart()
    {
        base.OnStart();
        _summonerFettle = FindObjectOfType<NullFettle>();
    }
}
