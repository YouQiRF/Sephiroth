using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;

public class Event_OwlAttack : TurntableGeneric
{
    private int hitEnemy;
    private int thisLocation;
    
    public override void OnPointed()
    {
        if (FindObjectOfType<OwlFettle>().StatyLocation > FindObjectOfType<PlayerFettle>().StatyLocation)
        {
            OnStrike();
        }
        else
        {
            OnGuerrilla();
        }
    }

    private void OnGuerrilla()
    {
        LocationManager.instance.EnemyOnAttackDetected(1);
        LocationMove();
    }

    private void OnStrike()
    {
        EnemyDetected();
        LocationManager.instance.OtherAttackDetected(1,hitEnemy);
    }

    private void LocationMove()
    {
        thisLocation = FindObjectOfType<OwlFettle>().StatyLocation;
        LocationManager.instance.PlayerLocation[3] = LocationManager.instance.PlayerLocation[thisLocation];
        LocationManager.instance.PlayerLocation[4] = LocationManager.instance.PlayerLocation[thisLocation+1];
        LocationManager.instance.PlayerLocation[3].StatyLocation = thisLocation+1;
        LocationManager.instance.PlayerLocation[4].StatyLocation = thisLocation;
        LocationManager.instance.PlayerLocation[thisLocation] = LocationManager.instance.PlayerLocation[4];
        LocationManager.instance.PlayerLocation[thisLocation+1] = LocationManager.instance.PlayerLocation[3];
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

    /*var AttackNumber = FindObjectOfType<LocationManager>();
        var AttackAN = GameObject.Find("OwlANA").GetComponent<AttackDisPlay_Player>();
        AttackNumber.EnemyOnAttackDetected(1);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_S,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
        AttackAN.OnAttackDisPlay();*/
}
