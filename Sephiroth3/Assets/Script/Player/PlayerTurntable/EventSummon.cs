using System;
using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;

public class EventSummon : TurntableGeneric
{
    [SerializeField] public int ThisNo;
    [SerializeField] public bool IsSummon;
    public override void OnPointed()
    {
        //base.OnPointed();
        if (IsSummon)
        {
            ChangeLocation();
            //Debug.Log("SummonA");
        }
        else
        {
            CheckIsFirst();
            //Debug.Log("SummonB");
        }

        //Debug.Log("Summon");
    }

    private void ChangeLocation()
    {
        string thisSummonerName = ThisNo == 1 ? "TheSummonerA" : "TheSummonerB";
        var thisFettle = GameObject.Find(thisSummonerName).GetComponent<FettleGeneric>();
        thisFettle.OnSetLocation();
    }

    private void CheckIsFirst()
    {
        var otherSummonerName = ThisNo == 1 ? "SummonB" : "SummonA";
        var thisSummonerName = ThisNo == 1 ? "TheSummonerA" : "TheSummonerB";
        var locationM = FindObjectOfType<LocationManager>();
        var otherSummoner = GameObject.Find(otherSummonerName).GetComponent<EventSummon>();
        var targetIndex = otherSummoner.IsSummon ? 2 : 0;
        var thisSummonerManager = GameObject.Find(thisSummonerName).GetComponent<SummonerManager>();
        if (thisSummonerManager._summonerFettle._hpData.NowHP > 0)
        {
            locationM.PlayerLocation[targetIndex] = GameObject.Find(thisSummonerName).GetComponent<FettleGeneric>();
            locationM.PlayerLocation[targetIndex].StatyLocation = otherSummoner.IsSummon ? 2 : 0;
            IsSummon = true;
            thisSummonerManager.OnSummoner();
            SummonEvent();
            ChangeSummonIcon();
        }
    }

    private void SummonEvent()
    {
        var Turntable = FindObjectOfType<TurntableManager>();
        var UI = FindObjectOfType<GameUIManager>();

        if (ThisNo == 1)
        {
            Turntable.SummonerTurntable[0].SetActive(true);
            UI.TurntableUI[0].SetActive(true);
        }
        else
        {
            Turntable.SummonerTurntable[1].SetActive(true);
            UI.TurntableUI[1].SetActive(true);
        }
        EventBus.Post(new PlayerOnSummonDetected());
    }

    private void ChangeSummonIcon()
    {
        var SummonIcon = GameObject.Find(FindName).GetComponent<AssignedDisplay>();
        SummonIcon.BackNumber = 3;
        SummonIcon.ShowNumber = 2;
        SummonIcon.Seticon();
    }

}
