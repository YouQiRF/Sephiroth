using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSupport : MonsterGeneric
{
    public override void AttackBehaviour()
    {
        var HealTarget = FindObjectOfType<LocationManager>();

        if (HealTarget.MonsterLocation[0] != null)
        {
            HealTarget.MonsterLocation[0].EnemyNowHP += AttackDamage;
            HealTarget.MonsterLocation[0].GetHealEffect();
        }
        else
        {
            if (HealTarget.MonsterLocation[1] != null)
            {
                HealTarget.MonsterLocation[1].EnemyNowHP += AttackDamage;
                HealTarget.MonsterLocation[1].GetHealEffect();
            }
            else
            {
                HealTarget.MonsterLocation[2].EnemyNowHP += AttackDamage;
                HealTarget.MonsterLocation[2].GetHealEffect();
            }
        }
    }

    public override void FettleUISet()
    {
        base.FettleUISet();
        BehaciourImgChange(4,5);
    }
}
