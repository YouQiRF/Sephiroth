using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFettle : FettleGeneric
{
    [SerializeField] private int BeforLocaTion;
    [SerializeField] private int hitEnemy;
    
    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnSetLocation()
    {
        BeforLocaTion = StatyLocation;
        EnemyDetected();
        base.OnSetLocation();
        if (BeforLocaTion > StatyLocation)
        {
            LocationManager.instance.OtherAttackDetected(8,hitEnemy);
            Debug.Log("AttackFront");
        }
        else
        {
            LocationManager.instance.EnemyOnAttackDetected(8);
            Debug.Log("AttackBehind");
        }
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
