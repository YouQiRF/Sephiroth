using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwlFettle : FettleGeneric
{
    [SerializeField] public bool DoubleReady;
    public override void OnStart()
    {
        base.OnStart();
    }
    
    public override void OnHit(float GetDamage)
    {
        base.OnHit(GetDamage);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Attack_Basic,Creat_Effect_Player.instance.Buff_Hit_pos[StatyLocation]);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_S,Creat_Effect_Player.instance.Buff_Hit_pos[StatyLocation]);
    }

    public override void OnDead()
    {
        var Turntable = FindObjectOfType<TurntableManager>();
        var UI = FindObjectOfType<GameUIManager>();
        base.OnDead();
        Turntable.SummonerTurntable[1].SetActive(false);
        UI.TurntableUI[1].SetActive(false);
    }
}
