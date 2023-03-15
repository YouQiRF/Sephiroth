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

    // Update is called once per frame
    void Update()
    {
        
    }
}
