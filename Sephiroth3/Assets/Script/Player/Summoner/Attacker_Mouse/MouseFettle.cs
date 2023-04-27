using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MouseFettle : FettleGeneric
{
    [SerializeField] private int BeforLocaTion;
    [SerializeField] private int hitEnemy;
    
    public override void OnStart()
    {
        base.OnStart();
    }

    public async override void OnSetLocation()
    {
        var MouseAN = GameObject.Find("Mouse_Animation").GetComponent<Animator>();
        var AttackMove = GameObject.Find("MouseAN").GetComponent<AttackDisPlay_Player>();
        BeforLocaTion = StatyLocation;
        EnemyDetected();
        base.OnSetLocation();
        MouseAN.Play("mouse_attack");
        await Task.Delay(600);
        if (BeforLocaTion > StatyLocation)
        {
            LocationManager.instance.OtherAttackDetected(8,hitEnemy);
            //Debug.Log("AttackFront");
        }
        else
        {
            LocationManager.instance.EnemyOnAttackDetected(8);
            //Debug.Log("AttackBehind");
        }
        AttackMove.OnAttackDisPlay();
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_M,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
    }
    
    private void EnemyDetected()
    {
        if (LocationManager.instance.MonsterLocation[2] != null)
        {
            hitEnemy = 2;
        }
        else
        {
            if (LocationManager.instance.MonsterLocation[1] != null)
            {
                hitEnemy = 1;
            }
            else
            {
                hitEnemy = 0;
            }
        }
    }
}
