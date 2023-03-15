using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_WolfDefnse : TurntableGeneric
{
    public override void OnPointed()
    {
        var wolf = FindObjectOfType<WolfManager>();
        wolf._summonerFettle._hpData.ArmorValue += wolf._summonerFettle._hpData.ArmorDefense;
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Buff_Armor,Creat_Effect_Player.instance.Buff_Armor_pos[wolf._summonerFettle.StatyLocation]);
        MusicManager.instance.PlayDefense();
    }
    
}
