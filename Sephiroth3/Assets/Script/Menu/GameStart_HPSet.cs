using System;
using System.Collections;
using System.Collections.Generic;
using Project.PlayerHpData;
using UnityEngine;

public class GameStart_HPSet : MonoBehaviour
{
    [SerializeField] private HpData[] _hpData;
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("NeedReset",1);
            Debug.Log(PlayerPrefs.GetInt("NeedReset"));
        }
    }

    public void OnStartSet()
    {
        _hpData[0].NowHP = 111;
        _hpData[1].NowHP = 222;
        _hpData[2].NowHP = 333;
        _hpData[3].NowHP = 444;
        PlayerPrefs.SetInt("SummonerA",1);
        PlayerPrefs.SetInt("SummonerB",0);
    }
}
