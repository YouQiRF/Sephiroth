using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Event_MouseAttack : TurntableGeneric
{
    public async override void OnPointed()
    {
        //var AttackNumber = FindObjectOfType<LocationManager>();
        //var AttackAN = GameObject.Find("WolfAN").GetComponent<AttackDisPlay_Player>();
        var AttackAN = GameObject.Find("MouseAN").GetComponent<AttackDisPlay_Player>();
        var MouseAN = GameObject.Find("Mouse_Animation").GetComponent<Animator>();
        MouseAN.Play("mouse_attack");
        await Task.Delay(600);
        LocationManager.instance.EnemyOnAttackDetected(1);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_M,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
        AttackAN.OnAttackDisPlay();//Debug.Log("Attackwolf");
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_M,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
    }
}
