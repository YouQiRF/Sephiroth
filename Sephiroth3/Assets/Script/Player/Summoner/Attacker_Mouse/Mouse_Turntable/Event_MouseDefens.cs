using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_MouseDefens : TurntableGeneric
{
    public override void OnPointed()
    {
        var Mouse = FindObjectOfType<MouseManager>();
        Mouse._summonerFettle._hpData.ArmorValue += 2;
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Buff_Armor,Creat_Effect_Player.instance.Buff_Armor_pos[Mouse._summonerFettle.StatyLocation]);
        MusicManager.instance.PlayDefense();
    }
}
