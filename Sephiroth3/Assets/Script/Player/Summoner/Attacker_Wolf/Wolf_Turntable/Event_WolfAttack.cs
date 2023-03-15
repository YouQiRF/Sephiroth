using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;

public class Event_WolfAttack : TurntableGeneric
{
    public override void OnPointed()
    {
        var AttackNumber = FindObjectOfType<LocationManager>();
        var AttackAN = GameObject.Find("WolfANA").GetComponent<AttackDisPlay_Player>();
        AttackNumber.EnemyOnAttackDetected(2);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_Attack,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
        AttackAN.OnAttackDisPlay();//Debug.Log("Attackwolf");
    }
}
