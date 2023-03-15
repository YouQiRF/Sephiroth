using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;

public class PlayerRound : IState
{
    public void OnEnterState(object action)
    {
        var actor = (PlayerActor) action;
        actor.NowActorPoints = 1;
        //throw new System.NotImplementedException();
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //actor._pointerManager.OnStopPointer();
            EventBus.Post(new StopTruntableDetected());
            actor.changeState(new WaitRound());
        }
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        actor.NowActorPoints = 0;
        //throw new System.NotImplementedException();
    }
}
