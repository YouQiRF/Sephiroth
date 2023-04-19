using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_WolfDefnse : TurntableGeneric
{
    public override void OnPointed()
    {
        var wolf = FindObjectOfType<WolfManager>();
        if (FindObjectOfType<WolfFettle>().StatyLocation > FindObjectOfType<PlayerFettle>().StatyLocation)
        {
            wolf._summonerFettle._hpData.ArmorValue += wolf._summonerFettle._hpData.ArmorDefense;
        }
        else
        {
            wolf._summonerFettle._hpData.ArmorValue += (wolf._summonerFettle._hpData.ArmorDefense * 2f);
        }
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Buff_Armor,Creat_Effect_Player.instance.Buff_Armor_pos[wolf._summonerFettle.StatyLocation]);
        MusicManager.instance.PlayDefense();
    }
    
}
