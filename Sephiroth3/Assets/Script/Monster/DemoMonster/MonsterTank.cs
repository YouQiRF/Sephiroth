using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTank : MonsterGeneric
{
    public override void AttackBehaviour()
    {
        var StrikeTarget = FindObjectOfType<LocationManager>();
        if (StrikeTarget.PlayerLocation[0] == null)
        {
            StrikeTarget.PlayerLocation[1].OnHit(5);
            StrikeTarget.PlayerLocation[2].OnHit(5);
        }
        else
        {
            if (StrikeTarget.PlayerLocation[1] == null)
            {
                StrikeTarget.PlayerLocation[2].OnHit(5);
            }
            else
            {
                StrikeTarget.PlayerLocation[0].OnHit(5);
                StrikeTarget.PlayerLocation[1].OnHit(5);
            }
        }
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_M,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
        MusicManager.instance.PlayHit();
    }
}
