using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDefense : TurntableGeneric
{
    
    public override void OnPointed()
    {
        var player = FindObjectOfType<PlayerManager>();
        player._playerFettle._hpData.ArmorValue += player._playerFettle._hpData.ArmorDefense;
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Buff_Armor,Creat_Effect_Player.instance.Buff_Armor_pos[player._playerFettle.StatyLocation]);
        MusicManager.instance.PlayDefense();
    }
}
