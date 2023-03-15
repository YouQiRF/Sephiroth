using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRound : IState
{
    public void OnEnterState(object action)
    {
        var actor = (PlayerActor) action;
        //throw new System.NotImplementedException();
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        //throw new System.NotImplementedException();
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        //throw new System.NotImplementedException();
    }
}
