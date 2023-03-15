using System;
using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using Project.PlayerHpData;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFettle : FettleGeneric
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnHit(float GetDamage)
    {
        base.OnHit(GetDamage);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Attack_Basic,Creat_Effect_Player.instance.Buff_Hit_pos[StatyLocation]);
    }

    public override void OnDead()
    {
        EventBus.Post(new PlayerDeadDetected());
    }
}
